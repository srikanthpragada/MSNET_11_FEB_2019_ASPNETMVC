using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace aspnetmvc.Controllers
{
    public class DateTimeController : ApiController
    {
        [HttpGet]
        public String Get()
        {
            return DateTime.Now.ToString(); 
        }

        [HttpGet]
        public String Get(int id)
        {
            if (id == 1)
                return DateTime.Today.ToLongDateString();
            else
                return DateTime.Now.ToLongTimeString();
        }


    }
}