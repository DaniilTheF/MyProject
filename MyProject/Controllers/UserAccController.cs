using Microsoft.AspNetCore.Mvc;
using MyProject.Objects.DB;
using MyProject.Objects.Interfaces;
using MyProject.Objects.Models;
using System.Linq;

namespace MyProject.Controllers
{
    public class UserAccController : Controller
    {
        private readonly DataBase DB;
        private readonly IGetUserAcc getUsera;
        public UserAccController(DataBase DB, IGetUserAcc getUsera)
        {
            this.DB = DB;
            this.getUsera = getUsera;
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(UserAcc usera)
        {
            getUsera.usera = getUsera.GetUsera(usera);

            if (getUsera.usera.Count() == 1)
            {
                if (ModelState.IsValid)
                {
                    getUsera.CreateOrder(usera);
                    return RedirectToAction("Complet");
                }
            }

            return View(usera);
        }
        public IActionResult Complet()
        {
            ViewBag.Message = "Вы успешно купили продукцию";
            return View();
        }
    }
}
