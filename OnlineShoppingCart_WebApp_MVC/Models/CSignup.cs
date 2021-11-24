using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingCart_WebApp_MVC.Models
{
    public class CSignup
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^[0-9]{10,10}$", ErrorMessage = "phone number should contain only 10 digits")]
        public string Mobile { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*[0-9])[A-Za-z0-9]{8,}$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 Alphabet and 1 Number")]
        public string Password { get; set; }

       

        
       
    }
}