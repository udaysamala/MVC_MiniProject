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
            catch (Exception)
            {

                ViewBag.alert = "An Exception Occurred";
                return View();
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
                    ViewBag.alert = "Incorrect Login Credentials / No Data-Click On SignUp";

                    return View();

                }

            }
            catch (Exception)
            {
                ViewBag.alert = "An Exception Occurred";
                return View();

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

                    ViewBag.alert = "Registration Unsuccess! Please Try Again";
                    return View();

                }

            }
            catch (Exception)
            {
                ViewBag.alert = "An Exception Occurred";
                return View();

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
            catch (Exception)
            {

                ViewBag.alert = "An Exception Occurred";
                return View();
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
                        Quantity = a.Quantity,
                        TotalPrice=a.TotalPrice,
                        TotalBillPrice=a.TotalBillPrice
                       
                    });
                }
                return View(finallist);

            }
            catch (Exception)
            {
                ViewBag.alert = "An Exception Occurred";
                return View();

            }

        }
        public ActionResult UserSearchProduct()
        {
            return View();

        }
        [HttpPost]
        public ActionResult UserSearchedProduct(SearchProduct spm)
        {
            try
            {
                Product pro = new Product()
                {
                    SearchProduct=spm.Producttosearch,

                };

                List<Product> lst = bl.UserSearchedProduct(pro);
                
                List<UserViewProductsModel> lstOfFinalProduct = new List<UserViewProductsModel>();
                foreach (Product p in lst)
                {
                    lstOfFinalProduct.Add(new UserViewProductsModel()
                    {
                        Name = p.Name,
                        Price = p.Price,
                        Quantity = p.Quantity
                    });
                }
                if (lst != null)
                {
                    return View(lstOfFinalProduct);
                }
                else
                {
                    ViewBag.alert = "Sorry, the item is out of stock..";
                    return View("UserSearchProduct");

                }

            }
            catch (Exception)
            {
                ViewBag.alert = "An Exception Occurred";
                return View();

            }

        }
        public ActionResult UserAddCart()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserAddCart(AddCartModel cm)
        {
            try
            {
                UserName cn = new UserName();
               
                    ADDCart c = new ADDCart()
                    {
                        Username = cn.Username,

                        Check = cm.Productname,

                        Quantity = cm.Quantity,

                    };
                    int result = bl.InsertintoCart(c);
                    if (result == 1)
                    {
                        ViewBag.alert = "Product Inserted Successfully";

                        return View();
                    }
                    if (result == -1)
                    {
                        ViewBag.alert = "Insufficient Product Quantity! Required Quantity more ";

                        return View();

                    }
                    else
                    {
                        ViewBag.alert = "Product Not-Inserted ! Try Again";
                        return View();
                    }

            }
            catch (Exception )
            {

                ViewBag.alert = "An Exception Occurred";
                return View();
            }

        }
        public ActionResult UserDeleteCart()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserDeleteCart(UserDeleteProductCartModel dp)
        {
            try
            {
               ADDCart ac = new ADDCart()
                {

                    Deleteproduct = dp.Deleteproduct,

                };
                int result = bl.UserDeleteProductItemFromCart(ac);
                if (result == 1)
                {
                    ViewBag.alert = "Item Removed Successfully";
                    return View();
                }
                else
                {
                    ViewBag.alert = "Sorry, the item was Not Removed..";
                    return View();
                }

            }
            catch (Exception)
            {

                ViewBag.alert = "An Exception Occurred";
                return View();
            }

        }
        public ActionResult Order()
        {
            int result =bl.Orders();
            if (result == 1)
            {
                ViewBag.alert = "Thanks for Shopping! Your Order was Placed";
                return RedirectToAction("UserMyOders");
            }
            else
            {
                ViewBag.alert = "Your Order was Not-Placed,Plaese Try Again!";
                return RedirectToAction("UserCart");
            }
            
            
        }
        public ActionResult UserMyOders()
        {
            try
            {

                List<Orders> lst = bl.FetchUserOrders();
                List<UserOders> finallist = new List<UserOders>();
                foreach (Orders o in lst)
                {
                    finallist.Add(new UserOders()
                    {
                        OrderId=o.Orderid,
                        ProductName=o.Productname,
                        Qunatity=o.Quantity,

                    });
                }
                return View(finallist);

            }
            catch (Exception)
            {
                ViewBag.alert = "An Exception Occurred";
                return View();

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

                    ViewBag.alert = "Incorrect Login Credentials";

                    return View();

                }

            }
            catch (Exception )
            {
                ViewBag.alert = "An Exception Occurred";
                return View();

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
            catch (Exception)
            {

                ViewBag.alert = "An Exception Occurred";
                return View();
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
                    ProductId=ap.ProductId,
                    Name=ap.Name,
                    Price = ap.Price,
                    Discount=ap.Discount,
                    Quantity=ap.Quantity,
                    Summary = ap.Summary,
                };
                int result= bl.InsertintoProductTable(p);
                if (result == 1)
                {
                    ViewBag.alert = "Product Inserted Successfully";

                    return View();
                }
                else
                {
                    ViewBag.alert = "Product Not-Inserted ! Try Again";
                    return View();
                }

            }
            catch (Exception )
            {
                ViewBag.alert = "An Exception Occurred";
                return View();
                
            }

        }
        public ActionResult AdminSearchProduct()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AdminSearchedProduct(SearchProduct spm)
        {
            try
            {
                Product pro = new Product()
                {
                    SearchProduct = spm.Producttosearch,

                };

                List<Product> lst = bl.AdminSearchedProduct(pro);

                List<AdmiViewProducts> lstOfFinalProduct = new List<AdmiViewProducts>();
                foreach (Product p in lst)
                {
                    lstOfFinalProduct.Add(new AdmiViewProducts()
                    {
                       ProductId = p.ProductId,
                        Name = p.Name,
                        Price = p.Price,
                        Quantity = p.Quantity
                    });
                }
                if (lst != null)
                {
                    return View(lstOfFinalProduct);
                }
                else
                {
                    ViewBag.alert = "Sorry, the item is out of stock..";
                    return RedirectToAction("AdminSearchProduct");

                }

            }
            catch (Exception)
            {
                ViewBag.alert = "An Exception Occurred";
                return View();

            }

        }
        public ActionResult AdminDeleteProduct()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AdminDeleteProduct(AdminDeleteProduct dp)
        {
            try
            {
                Product p = new Product()
                {

                    Deleteproduct = dp.Deleteproduct,
                   
                };
                int result = bl.DeleteProductItem(p);
                if (result == 1)
                {
                    ViewBag.alert = "Item Deleted Successfully";
                    return View();
                }
                else
                {
                    ViewBag.alert = "Sorry, the item was Not Deleted..";
                    return View();
                }

            }
            catch (Exception )
            {
               
                ViewBag.alert = "An Exception Occurred";
                return View();
            }

        }
        

    }
}