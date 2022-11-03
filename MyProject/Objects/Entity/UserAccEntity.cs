using MyProject.Objects.DB;
using MyProject.Objects.Models;
using MyProject.Objects.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyProject.Objects.Entity
{
    public class UserAccEntity : IGetUserAcc
    {

        private readonly DataBase DB;
        private readonly ProductsBasket productsBasket;
        public IEnumerable<UserAcc> usera { get; set; }
        public UserAccEntity(DataBase DB, ProductsBasket productsBasket)
        {

            this.DB = DB;
            this.productsBasket = productsBasket;
        }
        public IEnumerable<UserAcc> GetUsera(UserAcc user)
        {
            return DB.UserAcc.Where(u => u.Loggin == user.Loggin && u.Password == user.Password).ToList();
        }
        public void CreateOrder(UserAcc user)
        {
            var products = productsBasket.list;
            foreach (ItemProductsBasket items in products)
            {
                Order order = new Order()
                {
                    OrderId = user.Id,
                    Products = items.Product,
                    TotalCost = items.Product.Cost
                };
                DB.Order.Add(order);
            }
            DB.SaveChanges();
        }
    }
}
