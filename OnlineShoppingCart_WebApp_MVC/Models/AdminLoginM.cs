using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingCart_WebApp_MVC.Models
{
    public class AdminLoginM
    {
        [Required(ErrorMessage ="Please Enter UserName")]
        public string User { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Pass { get; set; }
    }
}