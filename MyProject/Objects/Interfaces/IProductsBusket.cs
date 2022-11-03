using MyProject.Objects.Models;
using System.Collections.Generic;

namespace MyProject.Objects.Interfaces
{
    public interface IProductsBusket
    {
        public string ProductBasketID { get; set; }
        public IEnumerable<ItemProductsBasket> list { get; set; }
        public void AddToBasked(Products product); 
        public void RemoveFromBasked(int ID);
        public void GetBasket();
    }
}
