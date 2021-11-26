using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingCart_WebApp_MVC.Models
{
    public class AdminDeleteProduct
    {
        [Required]
        public string Deleteproduct { get; set; }
    }
}