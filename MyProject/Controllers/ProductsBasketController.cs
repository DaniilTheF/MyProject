using Microsoft.AspNetCore.Mvc;
using MyProject.Objects.Interfaces;
using MyProject.ViewModels;
using System.Linq;


namespace MyProject.Controllers
{

        public class ProductsBasketController : Controller
        {
            private readonly IGetProducts getProducts;
            private readonly IProductsBusket productsBasket;
        public ProductsBasketController(IGetProducts getProducts, IProductsBusket productsBasket)
            {
                this.getProducts = getProducts;
                this.productsBasket = productsBasket;
            }

            public ViewResult Basket()
            {
            productsBasket.GetBasket();
            var model = new ProductsBasketViewModel
                {
                    productsBasket = productsBasket
                };
                return View(model);
            }

            public RedirectToActionResult RedirectToNewBasket(int productId)
            {

                productsBasket.RemoveFromBasked(productId);

                return RedirectToAction("Basket");
            }

            public RedirectToActionResult RedirectToBasket(int productId)
            {
                var product = getProducts.IProducts.FirstOrDefault(i => i.Id == productId);
                if (product != null)
                {
                    productsBasket.AddToBasked(product);
                }
                return RedirectToAction("Basket");
            }
        }
    

}
