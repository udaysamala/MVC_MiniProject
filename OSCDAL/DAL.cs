using OSCDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCDAL
{
    public class DAL
    {
        SqlConnection sqlConObj;
        SqlConnection sqlConObj1;
        SqlConnection sqlConObj2;
        SqlCommand sqlCmdObj;
        SqlDataReader sqlDataReaderObj;
        SqlDataReader sqlDataReaderObj1;
        public DAL()
        {
            sqlConObj = new SqlConnection();
            sqlConObj1 = new SqlConnection();
            sqlConObj2 = new SqlConnection();
            sqlCmdObj = new SqlCommand();
        }
        public int Login(Customer c)
        {
            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.ConnectionStrings["OnlineShoppingCart"].ConnectionString;
                bool check = false;
                UserName un = new UserName();
                sqlConObj.Open();
                string query = "Select * from dbo.users";
                SqlCommand cmd = new SqlCommand(query, sqlConObj);
                SqlDataReader col = cmd.ExecuteReader();
                while (col.Read())
                {
                    if (c.Username == System.Convert.ToString(col[3]) && c.Password == System.Convert.ToString(col[4]))
                    {
                        check = true;
                        un.Username = col[1].ToString();
                        break;
                    }
                }
                sqlConObj.Close();
                if (check == true)
                    
                return 1;
                else
                    return -1;
            }
            catch(Exception e) { throw e; }
        }
        public int AdminLogin(Admin a)
        {
            if (a.User == "admin" && a.Pass == "admin")
            {
                return 1;
            }
            else
                return -1;
        }
        public int signup(Customer c)
        {
            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.ConnectionStrings["OnlineShoppingCart"].ConnectionString;
                string query = $"insert into dbo.users(name,mobile,email, Password,registeredAt) values('{c.Name}','{c.Mobile}','{c.Username}','{c.Password}',getdate())";
                SqlCommand cmd = new SqlCommand(query, sqlConObj);
                sqlConObj.Open();
                int insertedRows = cmd.ExecuteNonQuery();
                sqlConObj.Close();
                if (insertedRows >= 1)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
                
            }

            catch(Exception e) { throw e ; }
        }
        public int InsertintoProduct(Product p)
        {
            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.ConnectionStrings["OnlineShoppingCart"].ConnectionString;
                string query = $"insert into dbo.product(id,Name,summary,price,discount,quantity) values('{p.ProductId}','{p.Name}','{p.Summary}','{p.Price}','{p.Discount}','{p.Quantity}')";
                SqlCommand cmd = new SqlCommand(query, sqlConObj);
                sqlConObj.Open();
                int insertedRows = cmd.ExecuteNonQuery();
                sqlConObj.Close();
                if (insertedRows >= 1)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }

            }

            catch (Exception e) { throw e; }
        }
        public int InsertintoCart(ADDCart cr)
        {
            int qcheck=0;
            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.ConnectionStrings["OnlineShoppingCart"].ConnectionString;
                string query = $"select id,name,quantity,price from product where  name ='{cr.Check}';";
                SqlCommand cmd = new SqlCommand(query, sqlConObj);
                sqlConObj.Open();
                sqlDataReaderObj = cmd.ExecuteReader();
                while (sqlDataReaderObj.Read())
                {

                    {
                        cr.Productid = sqlDataReaderObj[0].ToString();
                        cr.Productname = sqlDataReaderObj[1].ToString();
                        qcheck = Convert.ToInt32(sqlDataReaderObj[2]);
                        cr.Price =Convert.ToInt32(sqlDataReaderObj[3]);
                    };

                }
                UserName c = new UserName();
                float totalprice =cr.Price * cr.Quantity;
                sqlConObj.Close();
                if (cr.Quantity <= qcheck)
                {
                    string query1 = $"insert into dbo.cart(username,productid,Productname,quantity,productprice,TotalPrice) values('{c.Username}','{cr.Productid}','{cr.Productname}','{cr.Quantity}','{cr.Price}',{totalprice})";
                    SqlCommand cmd1 = new SqlCommand(query1, sqlConObj);
                    sqlConObj.Open();
                    int insertedRows2 = cmd1.ExecuteNonQuery();
                    sqlConObj.Close();
                    if (insertedRows2 >= 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }

                }
                else
                {
                    return -1;
                }


            }

            catch (Exception e) { throw e; }
            
        }
        public int InsertIntoOrders()
        {
            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.ConnectionStrings["OnlineShoppingCart"].ConnectionString;
                sqlConObj1.ConnectionString = ConfigurationManager.ConnectionStrings["OnlineShoppingCart"].ConnectionString;
                sqlConObj2.ConnectionString = ConfigurationManager.ConnectionStrings["OnlineShoppingCart"].ConnectionString;
                UserName c = new UserName();
                string query = $"SELECT productid,productname,quantity,productprice,TotalPrice FROM dbo.cart WHERE username = '{c.Username}'";
                SqlCommand cmd = new SqlCommand(query, sqlConObj);
                sqlConObj.Open();
                sqlDataReaderObj = cmd.ExecuteReader();
                List<Orders> lst = new List<Orders>();
                int sum = 0;
                while (sqlDataReaderObj.Read())
                {
                    sum += Convert.ToInt32(sqlDataReaderObj[4]);
                    string productid = sqlDataReaderObj[0].ToString();
                    Orders o = new Orders();

                        o.Productid = sqlDataReaderObj[0].ToString();
                        o.Productname = sqlDataReaderObj[1].ToString();
                        o.Quantity = Convert.ToInt32(sqlDataReaderObj[2]);
                        o.ProductPrice = Convert.ToInt32(sqlDataReaderObj[3]);
                        o.TotalPrice = Convert.ToInt32(sqlDataReaderObj[4]);
                        o.TotalBillPrice = sum;
                    
                    string query1 = $"SELECT quantity FROM dbo.product WHERE id='{productid}'";
                    SqlCommand cmd1 = new SqlCommand(query1, sqlConObj1);
                    sqlConObj1.Open();
                    sqlDataReaderObj1 = cmd1.ExecuteReader();
                    sqlDataReaderObj1.Read();
                    int quantity = Convert.ToInt32(sqlDataReaderObj1[0]);
                    o.UpdateQuantity = quantity - o.Quantity;
                    sqlCmdObj.CommandText = @"usp_Orders";
                    sqlCmdObj.CommandType = CommandType.StoredProcedure;
                    sqlCmdObj.Connection = sqlConObj2;
                    sqlCmdObj.Parameters.AddWithValue("@ProductId", o.Productid);
                    sqlCmdObj.Parameters.AddWithValue("@ProductName", o.Productname);
                    sqlCmdObj.Parameters.AddWithValue("@Productprice", o.ProductPrice);
                    sqlCmdObj.Parameters.AddWithValue("@userrequiredquantity", o.Quantity);
                    sqlCmdObj.Parameters.AddWithValue("@UserName","");
                    sqlCmdObj.Parameters.AddWithValue("@ProductTotalPrice", o.TotalPrice);
                    sqlCmdObj.Parameters.AddWithValue("@TotalBillPrice", o.TotalBillPrice);
                    sqlCmdObj.Parameters.AddWithValue("@updatequantity", o.UpdateQuantity);
                    SqlParameter sqlpm = new SqlParameter();
                    sqlpm.Direction = ParameterDirection.ReturnValue;
                    sqlpm.SqlDbType = SqlDbType.Int;
                    sqlCmdObj.Parameters.Add(sqlpm);
                    sqlConObj2.Open();
                    sqlCmdObj.ExecuteNonQuery();
                    //return Convert.ToInt32(sqlpm.Value);
                }
                return 1;
            }
            catch (Exception e)
            {

                throw e;
            }
         
        }
        public int DeleteItemfrmProduct(Product p)
        {
            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.ConnectionStrings["OnlineShoppingCart"].ConnectionString;
                string query = $"DELETE FROM product WHERE Id={p.Deleteproduct};";
                SqlCommand cmd = new SqlCommand(query, sqlConObj);
                sqlConObj.Open();
                int DeleteRows = cmd.ExecuteNonQuery();
                sqlConObj.Close();
                if (DeleteRows >= 1)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }

            }

            catch (Exception e) { throw e; }
        }
        public List<Product> FetchAllProducts()
        {
            
            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.ConnectionStrings["OnlineShoppingCart"].ConnectionString;
                sqlCmdObj.CommandText = @"SELECT Name,price,quantity FROM dbo.product";
                sqlCmdObj.Connection = sqlConObj;
                sqlConObj.Open();
                sqlDataReaderObj = sqlCmdObj.ExecuteReader();
                List<Product> lstPro = new List<Product>();
                Product newepartObj = new Product();
                while (sqlDataReaderObj.Read())
                {
                    lstPro.Add(new Product()
                    {
                        Name = sqlDataReaderObj[0].ToString(),
                        Price = sqlDataReaderObj[1].ToString(),
                        Quantity  = sqlDataReaderObj[2].ToString(),
                    });

                }
                return lstPro;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                sqlConObj.Close();
            }

        }
        public List<ADDCart> FetchCart()
        {

            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.ConnectionStrings["OnlineShoppingCart"].ConnectionString;
                UserName c = new UserName();
                string query = $"SELECT productname,quantity,productprice,TotalPrice FROM dbo.cart WHERE username = '{c.Username}'";
                SqlCommand cmd = new SqlCommand(query, sqlConObj);
                sqlConObj.Open();
                sqlDataReaderObj = cmd.ExecuteReader();
                List<ADDCart> lstCart = new List<ADDCart>();
                ADDCart newepartObj = new ADDCart();
                float sum = 0;
                while (sqlDataReaderObj.Read())
                {
                    sum += Convert.ToInt32(sqlDataReaderObj[3]);
                    lstCart.Add(new ADDCart()
                    {
                        Productname = sqlDataReaderObj[0].ToString(),
                        Price = Convert.ToInt32(sqlDataReaderObj[1]),
                        Quantity =Convert.ToInt32(sqlDataReaderObj[2]),
                        TotalPrice=Convert.ToInt32(sqlDataReaderObj[3]),
                        TotalBillPrice=sum,
                    });

                }
                return lstCart;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                sqlConObj.Close();
            }

        }
        public List<Product> AdminFetchProducts()
        {

            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.ConnectionStrings["OnlineShoppingCart"].ConnectionString;
                sqlCmdObj.CommandText = @"SELECT id,name,price,quantity,summary,discount FROM dbo.product";
                sqlCmdObj.Connection = sqlConObj;
                sqlConObj.Open();
                sqlDataReaderObj = sqlCmdObj.ExecuteReader();
                List<Product> lstPro1 = new List<Product>();
                Product newepartObj = new Product();
                while (sqlDataReaderObj.Read())
                {
                    lstPro1.Add(new Product()
                    {
                        ProductId= sqlDataReaderObj[0].ToString(),
                        Name = sqlDataReaderObj[1].ToString(),
                        Price = sqlDataReaderObj[2].ToString(),
                        Quantity = sqlDataReaderObj[3].ToString(),
                        Summary = sqlDataReaderObj[4].ToString(),
                        Discount=sqlDataReaderObj[5].ToString(),
                    });

                }
                return lstPro1;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                sqlConObj.Close();
            }

        }
        public List<Product> UserFetchSearchedProduct(Product p)
        {

            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.ConnectionStrings["OnlineShoppingCart"].ConnectionString;
                string query = $"SELECT name,price,quantity FROM dbo.product WHERE name like '{p.SearchProduct}%'";
                SqlCommand cmd = new SqlCommand(query, sqlConObj);
                sqlConObj.Open();
                sqlDataReaderObj = cmd.ExecuteReader();
                List<Product> lstPro = new List<Product>();
                while (sqlDataReaderObj.Read())
                {
                    lstPro.Add(new Product()
                    {
                        Name = sqlDataReaderObj[0].ToString(),
                        Price = sqlDataReaderObj[1].ToString(),
                        Quantity = sqlDataReaderObj[2].ToString(),

                    });

                }
                return lstPro;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                sqlConObj.Close();
            }

        }
        public List<Product> AdminFetchSearchedProduct(Product p)
        {

            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.ConnectionStrings["OnlineShoppingCart"].ConnectionString;
                string query = $"SELECT id,name,price,quantity FROM dbo.product WHERE name like '{p.SearchProduct}%' or id like '{p.SearchProduct}%'";
                SqlCommand cmd = new SqlCommand(query, sqlConObj);
                sqlConObj.Open();
                sqlDataReaderObj = cmd.ExecuteReader();
                List<Product> lstPro = new List<Product>();
                Product newepartObj = new Product();
                while (sqlDataReaderObj.Read())
                {
                    lstPro.Add(new Product()
                    {
                        ProductId= sqlDataReaderObj[0].ToString(),
                        Name = sqlDataReaderObj[1].ToString(),
                        Price = sqlDataReaderObj[2].ToString(),
                        Quantity = sqlDataReaderObj[3].ToString(),

                    });
                }
                return lstPro;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                sqlConObj.Close();
            }

        }
        public int UserDeleteProductItemFromCart(ADDCart ac)
        {
            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.ConnectionStrings["OnlineShoppingCart"].ConnectionString;
                string query = $"DELETE FROM cart WHERE productname='{ac.Deleteproduct}' and username='{ac.Username}';";
                SqlCommand cmd = new SqlCommand(query, sqlConObj);
                sqlConObj.Open();
                int DeleteRows = cmd.ExecuteNonQuery();
                sqlConObj.Close();
                if (DeleteRows >= 1)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }

            }

            catch (Exception e) { throw e; }
        }
        public List<Orders> FetchUserOrders()
        {

            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.ConnectionStrings["OnlineShoppingCart"].ConnectionString;
                UserName c = new UserName();
                string query = $"SELECT id,productname,userrequiredquantity FROM dbo.orders WHERE username = '{c.Username}'";
                SqlCommand cmd = new SqlCommand(query, sqlConObj);
                sqlConObj.Open();
                sqlDataReaderObj = cmd.ExecuteReader();
                List<Orders> lst = new List<Orders>();
                while (sqlDataReaderObj.Read())
                {
                    lst.Add(new Orders()
                    {
                        Orderid= sqlDataReaderObj[0].ToString(),
                        Productname = sqlDataReaderObj[1].ToString(),
                        Quantity = Convert.ToInt32(sqlDataReaderObj[2]),

                    });

                }
                return lst;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                sqlConObj.Close();
            }

        }


    }
}
