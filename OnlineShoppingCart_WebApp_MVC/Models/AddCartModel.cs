using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingCart_WebApp_MVC.Models
{
    public class AddCartModel
    {
        [Required]
        [Display(Name = "Product Name")]
        public string Productname { get; set; }
        [Required]
        public float Quantity { get; set; }
    }
}