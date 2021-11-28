using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingCart_WebApp_MVC.Models
{
    public class UserCart
    {
     
        public string Productname { get; set; }
        public float Quantity { get; set; }
        public float Price { get; set; }
        public float TotalPrice { get; set; }
        public float TotalBillPrice { get; set; }
    }
}