﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingCart_WebApp_MVC.Models
{
    public class UserCart
    {
     
        public string Productname { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
    }
}