using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingCart_WebApp_MVC.Models
{
    public class AdminAddProduct
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
        public string Quantity { get; set; }
    }
}