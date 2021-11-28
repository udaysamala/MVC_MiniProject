using OSCDAL;
using OSCDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCBL
{
    public class BL:IBL
    {
        DAL dalObj = new DAL();
        public int CheckLogin(Customer newObj)
        {
            try
            {
                
                int result = dalObj.Login(newObj);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int checkadminlogin(Admin newadmin)
        {
            try
            {
                int result = dalObj.AdminLogin(newadmin);
                return result;


            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public int regsignup(Customer newObj1)
        {
            try
            {

                int result = dalObj.signup(newObj1);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int InsertintoProductTable(Product newObj1)
        {
            try
            {

                int result = dalObj.InsertintoProduct(newObj1);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int InsertintoCart(ADDCart newObj)
        {
            try
            {

                int result = dalObj.InsertintoCart(newObj);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int DeleteProductItem(Product newObj)
        {
            try
            {

                int result = dalObj.DeleteItemfrmProduct(newObj);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int UserDeleteProductItemFromCart(ADDCart newObj)
        {
            try
            {

                int result = dalObj.UserDeleteProductItemFromCart(newObj);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Product> GetAllProductDetails()
        {
            try
            {
                
                List<Product> results = dalObj.FetchAllProducts();
                return results;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<Product> AdminProductDetails()
        {
            try
            {

                List<Product> results = dalObj.AdminFetchProducts();
                return results;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ADDCart> FetchCart()
        {
            try
            {

                List<ADDCart> results = dalObj.FetchCart();
                return results;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<Orders> FetchUserOrders()
        {
            try
            {

                List<Orders> results = dalObj.FetchUserOrders();
                return results;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<Product> UserSearchedProduct(Product p)
        {
            try
            {

                List<Product> results = dalObj.UserFetchSearchedProduct(p);
                return results;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<Product> AdminSearchedProduct(Product p)
        {
            try
            {

                List<Product> results = dalObj.AdminFetchSearchedProduct(p);
                return results;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public int Orders()
        {
            try
            {
                
                int result = dalObj.InsertIntoOrders();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
