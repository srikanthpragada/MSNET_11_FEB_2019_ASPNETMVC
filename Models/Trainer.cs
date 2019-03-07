using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnetmvc.Models
{
    public class Trainer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<String> Skills { get; set; }
    }
}