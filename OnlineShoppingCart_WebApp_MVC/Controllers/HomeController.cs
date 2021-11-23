using OnlineShoppingCart_WebApp_MVC.Models;
using OSCBL;
using OSCDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingCart_WebApp_MVC.Controllers
{
    public class HomeController : Controller
    {
        BL bl = new BL();

        
        public ActionResult Index()
        {
            try
            {

                List<Product> lstOfProduct = bl.GetAllProductDetails();
                List<UserViewProductsModel> lstOfFinalProduct = new List<UserViewProductsModel>();
                foreach (Product p in lstOfProduct)
                {
                    lstOfFinalProduct.Add(new UserViewProductsModel()
                    {
                        Name = p.Name,
                        Price = p.Price,
                        Quantity = p.Quantity
                    });
                }
                return View(lstOfFinalProduct);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(CCLogin loginmodel)
        {
            ViewBag.Message = "Your Login page.";
            try
            {
                Customer Cdto = new Customer()
                {
                   
                Username = loginmodel.Username,
                Password = loginmodel.Password,

            };
               
                int result1 = bl.CheckLogin(Cdto);
                
                if (result1 == 1)
                {
                    return View("UserHome");
                }
                else
                {

                    return View("Error");

                }

            }
            catch (Exception ex)
            {
                return View("Error");

            }

            
        }
        public ActionResult SignUp()
        {
            return View() ;

        }
        [HttpPost]
        public ActionResult SignUp(CSignup csmodel)
        {
            try
            {
                Customer Cdto = new Customer()
                {

                    Username = csmodel.Username,
                    Password = csmodel.Password,
                    Name = csmodel.Name,
                    Mobile=csmodel.Mobile,

                };

                int result1 = bl.regsignup(Cdto);

                if (result1 == 1)
                {
                    return View("Signupsuccess");
                }
                else
                {

                    return View("Error");

                }

            }
            catch (Exception ex)
            {
                return View("Error");

            }


        }
        public ActionResult UserHome()
        {
            try
            {

                List<Product> lstOfProduct = bl.GetAllProductDetails();
                List<UserViewProductsModel> lstOfFinalProduct = new List<UserViewProductsModel>();
                foreach (Product p in lstOfProduct)
                {
                    lstOfFinalProduct.Add(new UserViewProductsModel()
                    {
                        Name = p.Name,
                        Price = p.Price,
                        Quantity = p.Quantity
                    });
                }
                return View(lstOfFinalProduct);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}