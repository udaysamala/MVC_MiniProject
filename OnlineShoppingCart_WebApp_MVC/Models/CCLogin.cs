using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingCart_WebApp_MVC.Models
{
    public class CCLogin
    {
        [Required]
      
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }
}