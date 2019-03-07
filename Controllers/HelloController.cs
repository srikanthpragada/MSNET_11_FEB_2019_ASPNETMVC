using aspnetmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspnetmvc.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public ActionResult Index()
        {
            ViewBag.Message = "Good Morning!";
            ViewBag.Title = "ASP.NET MVC";
            return View();
        }

        // Hello/Trainer
        public ActionResult Trainer()
        {
            var t = new Trainer { Name = "Srikanth", Email = "srikanthpragada@gmail.com" };
            t.Skills = new List<String>();
            t.Skills.Add("MS.NET");
            t.Skills.Add("Java");
            t.Skills.Add("Python");
            t.Skills.Add("ML");
            return View(t);
        }
    }
}