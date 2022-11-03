
using Microsoft.AspNetCore.Mvc;
using MyProject.Objects.DB;
using MyProject.Objects.Interfaces;
using MyProject.Objects.Models;
using System.Linq;

namespace MyProject.Controllers
{

        public class UserController : Controller
        {

            private readonly DataBase DB;
            private readonly IGetUser getUser;
            public UserController(DataBase DB, IGetUser getUser)
            {
                this.DB = DB;
                this.getUser = getUser;
            }

            public IActionResult SignUp()
            {
                return View();
            }

            [HttpPost]
            public IActionResult SignUp(User user)
            {
                getUser.users = getUser.GetUser(user);

                if (getUser.users.Count() == 0)
                {
                    if (ModelState.IsValid)
                    {
                        getUser.AddToDB(user);
                        return RedirectToAction("Complete");
                    }
                }

                return View(user);
            }
            public IActionResult Complete()
            {
                ViewBag.Message = "Вы успешно прошли регистрацию";
                return View();
            }

        }
    }
