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
                    return RedirectToAction("UserHome");
                   
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
        public ActionResult UserCart()
        {
            try
            {

                List<ADDCart> lst = bl.FetchCart();
                List<UserCart> finallist = new List<UserCart>();
                foreach (ADDCart a in lst)
                {
                    finallist.Add(new UserCart()
                    {
                        Productname=a.Productname,
                        Price = a.Price,
                        Quantity = a.Quantity
                    });
                }
                return View(finallist);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ActionResult UserAddCart(AddCart cm)
        {
            try
            {
                ADDCart c = new ADDCart()
                {
                    Username=cm.Username,
                    Productid=cm.Productid,
                    Productname=cm.Productname,
                    Price=cm.Price,
                    Quantity=cm.Quantity,
                    Check=cm.Check,

                };

                return View();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(AdminLoginM alm)
        {
            ViewBag.Message = "Your Login page.";
            try
            {
               Admin a = new Admin()
                {

                    User = alm.User,
                    Pass = alm.Pass,

                };

                int result1 = bl.checkadminlogin(a);

                if (result1 == 1)
                {
                    return RedirectToAction("AdminViewProduct");

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
        public ActionResult AdminViewProduct()
        {
            try
            {

                List<Product> lst = bl.AdminProductDetails();
                List<AdmiViewProducts> finallist = new List<AdmiViewProducts>();
                foreach(Product p in lst)
                {
                    finallist.Add(new AdmiViewProducts()
                    {
                        ProductId=p.ProductId,
                        Name=p.Name,
                        Quantity=p.Quantity,
                        Summary = p.Summary,
                        Discount = p.Discount,
                        Price =p.Price,
                       

                        
                    });
                }

                return View(finallist);

            }
            catch (Exception ex)
            {

                return View("Error");
            }

        }
        public ActionResult AdminAddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminAddProduct(AdminAddProduct ap)
        {
            try
            {
                Product p = new Product()
                {
                    
                    Name=ap.Name,
                    Price = ap.Price,
                    Discount=ap.Discount,
                    Quantity=ap.Quantity,
                    Summary = ap.Summary,
                };
                int result= bl.InsertintoProductTable(p);
                if (result == 1)
                {
                    return View("AdminViewProduct");
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



    }
}