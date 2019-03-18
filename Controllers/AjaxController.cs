using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace aspnetmvc.Controllers
{
    public class AjaxController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public String DateAndTime()
        {
            return DateTime.Now.ToString(); 
        }

        [HttpPost]
        public ActionResult Search(int minprice, int maxprice)
        {
            var products = new List<string>();
            // Connect to Database 
            SqlConnection con = new SqlConnection(@"Data Source =(localdb)\mssqllocaldb; Initial Catalog=msdb;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand
                    ("select * from products where price between @min and @max", con);
                cmd.Parameters.AddWithValue("@min", minprice);
                cmd.Parameters.AddWithValue("@max", maxprice);
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    products.Add(reader["prodname"].ToString() + " - " + 
                           reader["price"].ToString());
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Sorry! Could not searh for products due to error!";
            }
            
            return PartialView("SearchResult", products);
        }
    }
}