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
    public class Admin { 

        public string User { get ; set; }
        public string Pass { get ; set ; }
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
        public string SearchProduct { get; set; }
    }
    public class ADDCart
    {

        public string Username { get; set; }
        public string Productid { get; set; }
        public string Productname { get; set; }
        public float Quantity { get; set ; }
        public float Price { get ; set; }
        public float TotalPrice { get; set; }

        public float TotalBillPrice { get; set; }
        public string Check { get; set; }
        public string Deleteproduct { get; set; }
    }
    public class Orders
    {
        public string Orderid { get; set; }
        public string Username { get; set; }
        public string Productid { get; set; }
        public string Productname { get; set; }
        public float Quantity { get; set; }
        public float ProductPrice { get; set; }
        public float TotalPrice { get; set; }
        public float TotalBillPrice { get; set; }
        public float UpdateQuantity { get; set; }

    }
    public class UserName
    {
        public string Username { get; set; }

    }

}
