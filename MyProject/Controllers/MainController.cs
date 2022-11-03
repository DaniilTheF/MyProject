using Microsoft.AspNetCore.Mvc;
using MyProject.Objects.Interfaces;
using MyProject.ViewModels;

namespace MyProject.Controllers
{
        public class MainController : Controller
        {
            private readonly IGetProducts getProducts;

            public MainController(IGetProducts getProducts)
            {
                this.getProducts = getProducts;
            }

            public ViewResult MainPage()
            {
            var products = new MainViewModel
            {
                Products = getProducts.IFavProducts
             };
                return View(products);
            }
        }

}
