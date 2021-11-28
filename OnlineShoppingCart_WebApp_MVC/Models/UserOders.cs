using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingCart_WebApp_MVC.Models
{
    public class UserOders
    {
        public string OrderId { get; set; }
        public string ProductName { get; set; }
        public float Qunatity { get; set; }
    }
}