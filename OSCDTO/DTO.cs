using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCDTO
{
    public class Customer
    {
        
        public string Password{get ; set ; }

        public string Username { get ; set; }
       
        public string Mobile { get ; set ; }
        public string Name { get; set ; }
    }
    public class Admin{
        string user ="admin";
        string pass = "admin";

        public string User { get => user; set => user = value; }
        public string Pass { get => pass; set => pass = value; }
    }
    public class Product
    {
        public string ProductId { get; set; }
        public string Name { get; set ; }
        public string Summary { get ; set; }
        public string Price { get; set; }
        public string Discount { get; set ; }
        public string Quantity { get ; set ; }
        public string Deleteproduct { get ; set; }
    }
    public class ADDCart
    {

        public string Username { get; set; }
        public string Productid { get; set; }
        public string Productname { get; set; }
        public string Quantity { get; set ; }
        public string Price { get ; set; }
        public string Check { get; set; }
    }

}
