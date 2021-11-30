using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingCart_WebApp_MVC.Models
{
    public class AdminAddProduct
    {
        [Required]
        [Display(Name = "Product ID")]
        public string ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Summary { get; set; }
        [Required]
        public string Price { get; set; }
        public string Discount { get; set; }
        [Required]
        public string Quantity { get; set; }
    }
}