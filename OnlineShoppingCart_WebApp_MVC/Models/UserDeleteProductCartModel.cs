using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingCart_WebApp_MVC.Models
{
    public class UserDeleteProductCartModel
    {
        [Required(ErrorMessage = "Please Enter ProductName To Delete")]
        [Display(Name = "Enter Product Name")]
        public string Deleteproduct { get; set; }
    }
}