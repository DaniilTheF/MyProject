using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyProject.Objects.DB;
using MyProject.Objects.Interfaces;
using MyProject.Objects.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyProject.Objects.Entity
{

   
        public class ProductsBasket : IProductsBusket
        {
            private readonly DataBase DB;
            public ProductsBasket(DataBase DB)
            {
                this.DB = DB;
            }

            public string ProductBasketID { get; set; }

            public IEnumerable<ItemProductsBasket> list { get; set; }


        public static ProductsBasket GetProductsBasket(IServiceProvider services)
            {
                ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
                DataBase context = services.GetService<DataBase>();
                string productBasketID = session.GetString("BasketId") ?? Guid.NewGuid().ToString();
                session.SetString("BasketId", productBasketID);
                return new ProductsBasket(context)
                {
                    ProductBasketID = productBasketID
                };
            }

            public void AddToBasked(Products product)
            {
                this.DB.ItemProductsBasket.Add(new ItemProductsBasket
                {
                    ProductBasketID = ProductBasketID,
                    Product = product
                });
                DB.SaveChanges();
            }

            public void RemoveFromBasked(int ID)
            {
                var ipb = DB.ItemProductsBasket.OrderBy(p => p.ID).Where(p => p.ID == ID).Last();
                this.DB.ItemProductsBasket.Remove(ipb);
                DB.SaveChanges();
            }
            public void GetBasket()
            {
                 list = DB.ItemProductsBasket.Where(c => c.ProductBasketID == ProductBasketID).Include(p => p.Product).ToList();
           
            }
        }
}
