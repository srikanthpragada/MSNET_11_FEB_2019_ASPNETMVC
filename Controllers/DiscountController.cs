using aspnetmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspnetmvc.Controllers
{
    public class DiscountController : Controller
    {
        // GET: Discount
        [HttpGet]
        public ActionResult Index()
        {
            Discount model = new Discount();
            return View(model);
        }

        // POST : Discount
        [HttpPost]
        public ActionResult Index(Discount model)
        {
            model.Result = model.Amount * model.Rate / 100; 
            return View(model);
        }
    }
}