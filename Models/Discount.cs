using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace aspnetmvc.Models
{
    public class Discount
    {
        [Range(1000,100000,ErrorMessage ="Amount must be between 1000 and 100000")]
        public double Amount { get; set; }

        [Range(5, 50, ErrorMessage = "Discount rate must be between 5 and 50")]
        public double Rate  { get; set; }

        public double Result { get; set; }

    }
}