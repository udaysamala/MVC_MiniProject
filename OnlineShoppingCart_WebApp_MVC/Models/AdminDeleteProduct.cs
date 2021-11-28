using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingCart_WebApp_MVC.Models
{
    public class AdminDeleteProduct
    {
        [Required(ErrorMessage = "Please Enter ProductName or ID")]
        [Display(Name = "Product Name Or ID")]
        public string Deleteproduct { get; set; }
    }
}