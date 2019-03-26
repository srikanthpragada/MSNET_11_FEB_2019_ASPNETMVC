using aspnetmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace aspnetmvc.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Home");
            }

            return View(user);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string pwd, string ReturnUrl)
        {
            if (pwd == "123")
            {
                // create cookie to authenticate user 
                FormsAuthentication.SetAuthCookie("user", true);
                return RedirectToAction("Add", "Books");
            }
            else
            {
                ViewBag.Message = "Sorry! Invalid password. Try again!";
            }
            return View();
        }
    }
}