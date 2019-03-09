using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace aspnetmvc.Models
{
    public class User
    {
        [StringLength(10,MinimumLength = 5,ErrorMessage ="Username must be 5 to 10 chars")]
        [Required]
        public string Name { get; set; }

        [StringLength(10, MinimumLength = 6, ErrorMessage = "Password must be 6 to 10 chars")]
        [Required]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Confirm Password does not match with password")]
        [Required]
        public string ConfirmPassword { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage ="Mobile must be 10 digits")]
        public string Mobile { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

    }
}