
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using onlinefood.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace onlinefood.Repository
{
    public class User
    {
        //User/To add the user details
        public string AddUserDetails(UserSignup objuser)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ToString());
                SqlCommand com = new SqlCommand("UserSignUp", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Query", 1);
                com.Parameters.AddWithValue("@FirstName", objuser.FirstName);
                com.Parameters.AddWithValue("@LastName", objuser.LastName);
                com.Parameters.AddWithValue("@DateofBirth", objuser.DateofBirth);
                com.Parameters.AddWithValue("@Gender", objuser.Gender);
                com.Parameters.AddWithValue("@PhoneNumber", objuser.PhoneNumber);
                com.Parameters.AddWithValue("@Email", objuser.Email);
                com.Parameters.AddWithValue("@Address", objuser.Address);
                com.Parameters.AddWithValue("@Username", objuser.Username);
                com.Parameters.AddWithValue("@Password", objuser.Password);
                com.Parameters.AddWithValue("@ConfirmPassword", objuser.ConfirmPassword);
                con.Open();
                result = com.ExecuteNonQuery().ToString();
                //result = com.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
            
         }

        //User/get the user details
        public List<UserSignup> GetUserDetails()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<UserSignup> userlist = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ToString());
                SqlCommand com = new SqlCommand("UserSignUp", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Query", 4);
                com.Parameters.AddWithValue("@UserId", null);
                com.Parameters.AddWithValue("@FirstName", null);
                com.Parameters.AddWithValue("@LastName", null);
                com.Parameters.AddWithValue("@DateofBirth", null);
                com.Parameters.AddWithValue("@Gender", null);
                com.Parameters.AddWithValue("@PhoneNumber", null);
                com.Parameters.AddWithValue("@Email", null);
                com.Parameters.AddWithValue("@Address", null);
                com.Parameters.AddWithValue("@Username", null);
                com.Parameters.AddWithValue("@Password", null);
                com.Parameters.AddWithValue("@ConfirmPassword", null);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = com;
                ds = new DataSet();
                da.Fill(ds);
                userlist = new List<UserSignup>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    UserSignup uobj = new UserSignup();
                    uobj.UserId = Convert.ToInt32(ds.Tables[0].Rows[i]["UserId"].ToString());
                    uobj.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                    uobj.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                    uobj.DateofBirth = Convert.ToDateTime(ds.Tables[0].Rows[i]["DateofBirth"].ToString());
                    uobj.Gender = ds.Tables[0].Rows[i]["Gender"].ToString();
                    uobj.PhoneNumber = ds.Tables[0].Rows[i]["PhoneNumber"].ToString();
                    uobj.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                    uobj.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                    userlist.Add(uobj);
                }

                return userlist;
            }
            catch
            {
                return userlist;
            }
            finally
            {
                con.Close();
            }
        }

        //User/Delete the user details
        public int DeleteUserDetails(String ID)
        {
            SqlConnection con = null;
            int result;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ToString());
                SqlCommand com = new SqlCommand("UserSignUp", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@UserId", ID);
                com.Parameters.AddWithValue("@FirstName", null);
                com.Parameters.AddWithValue("@LastName", null);
                com.Parameters.AddWithValue("@DateofBirth", null);
                com.Parameters.AddWithValue("@Gender", null);
                com.Parameters.AddWithValue("@PhoneNumber", null);
                com.Parameters.AddWithValue("@Email", null);
                com.Parameters.AddWithValue("@Address", null);
                com.Parameters.AddWithValue("@Username", null);
                com.Parameters.AddWithValue("@Password", null);
                com.Parameters.AddWithValue("@ConfirmPassword", null);
                com.Parameters.AddWithValue("@Query", 3);
                con.Open();
                result = com.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return result=0;
            }
            finally
            {
                con.Close();
            }
        }

        //User/Update the user details
        public string UpdateData(UserSignup objuser)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ToString());
                SqlCommand com = new SqlCommand("UserSignUp", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Query", 2);
                com.Parameters.AddWithValue("@UserId", objuser.UserId);
                com.Parameters.AddWithValue("@FirstName", objuser.FirstName);
                com.Parameters.AddWithValue("@LastName", objuser.LastName);
                com.Parameters.AddWithValue("@DateofBirth", objuser.DateofBirth);
                com.Parameters.AddWithValue("@Gender", objuser.Gender);
                com.Parameters.AddWithValue("@PhoneNumber", objuser.PhoneNumber);
                com.Parameters.AddWithValue("@Email", objuser.Email);
                com.Parameters.AddWithValue("@Address", objuser.Address);
                com.Parameters.AddWithValue("@Username", objuser.Username);
                com.Parameters.AddWithValue("@Password", objuser.Password);
                com.Parameters.AddWithValue("@ConfirmPassword", objuser.ConfirmPassword);
                con.Open();
                result = com.ExecuteScalar().ToString();
                return result;
            }
            
            catch
            {
                return result="";

            }
            finally
            {
               con.Close();
            }

        }
        //User/To get details of the user by id
        public UserSignup SelectDatabyID(String UserId)
        {
            SqlConnection con = null;
            DataSet ds = null;
            UserSignup uobj = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ToString());
                SqlCommand com = new SqlCommand("UserSignUp", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Query", 5);
                com.Parameters.AddWithValue("@UserId", UserId);
                com.Parameters.AddWithValue("@FirstName", null);
                com.Parameters.AddWithValue("@LastName", null);
                com.Parameters.AddWithValue("@DateofBirth", null);
                com.Parameters.AddWithValue("@Gender", null);
                com.Parameters.AddWithValue("@PhoneNumber", null);
                com.Parameters.AddWithValue("@Email", null);
                com.Parameters.AddWithValue("@Address", null);
                com.Parameters.AddWithValue("@Username", null);
                com.Parameters.AddWithValue("@Password", null);
                com.Parameters.AddWithValue("@ConfirmPassword", null);
               
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = com;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    uobj = new UserSignup();
                    uobj.UserId = Convert.ToInt32(ds.Tables[0].Rows[i]["UserId"].ToString());
                    uobj.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                    uobj.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                    uobj.DateofBirth = Convert.ToDateTime(ds.Tables[0].Rows[i]["DateofBirth"].ToString());
                    uobj.Gender = ds.Tables[0].Rows[i]["Gender"].ToString();
                    uobj.PhoneNumber = ds.Tables[0].Rows[i]["PhoneNumber"].ToString();
                    uobj.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                    uobj.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                }
                return uobj;
            }
            catch
            {
                return uobj;
            }
            finally
            {
                con.Close();
            }
        }

        //User/To add the order
        public string AddOrder(OrderModel objorder)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ToString());
                SqlCommand com = new SqlCommand("Order1", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Query", 1);
                com.Parameters.AddWithValue("@Name", objorder.Name);
                com.Parameters.AddWithValue("@Address", objorder.Address);
                com.Parameters.AddWithValue("@PhoneNumber", objorder.PhoneNumber);
                com.Parameters.AddWithValue("@ProductName", objorder.ProductName);
                com.Parameters.AddWithValue("@Description", objorder.Description);
                com.Parameters.AddWithValue("@Quantity", objorder.Quantity);
                //com.Parameters.AddWithValue("@Status", objorder.Status);
                con.Open();
                result = com.ExecuteNonQuery().ToString();
                //result = com.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }

        }
        //User/Get the order details
        public List<OrderModel> GetOrderDetails()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<OrderModel> orderlist = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ToString());
                SqlCommand com = new SqlCommand("Order1", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Query", 2);
                com.Parameters.AddWithValue("@OrderId", null);
                com.Parameters.AddWithValue("@Name", null);
                com.Parameters.AddWithValue("@Address", null);
                com.Parameters.AddWithValue("@PhoneNumber", null);
                com.Parameters.AddWithValue("@ProductName", null);
                com.Parameters.AddWithValue("@Description", null);
                com.Parameters.AddWithValue("@Quantity", null);
                //com.Parameters.AddWithValue("@Status", null);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = com;
                ds = new DataSet();
                da.Fill(ds);
                orderlist = new List<OrderModel>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    OrderModel oobj = new OrderModel();
                    oobj.OrderId = Convert.ToInt32(ds.Tables[0].Rows[i]["OrderId"].ToString());
                    oobj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    oobj.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                    oobj.PhoneNumber = ds.Tables[0].Rows[i]["PhoneNumber"].ToString();
                    oobj.ProductName = ds.Tables[0].Rows[i]["ProductName"].ToString();
                    oobj.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                    oobj.Quantity = Convert.ToInt32(ds.Tables[0].Rows[i]["Quantity"].ToString());
                    //oobj.Status = ds.Tables[0].Rows[i]["Status"].ToString();
                    orderlist.Add(oobj);
                }

                return orderlist;
            }
            catch
            {
                return orderlist;
            }
            finally
            {
                con.Close();
            }
        }

        //User/Delete the order details
        public int DeleteOrderDetails(String OrderId)
        {
            SqlConnection con = null;
            int result;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ToString());
                SqlCommand com = new SqlCommand("Order1", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@OrderId", OrderId);
                com.Parameters.AddWithValue("@Name", null);
                com.Parameters.AddWithValue("@Address", null);
                com.Parameters.AddWithValue("@PhoneNumber", null);
                com.Parameters.AddWithValue("@ProductName", null);
                com.Parameters.AddWithValue("@Description", null);
                com.Parameters.AddWithValue("@Quantity", null);
                com.Parameters.AddWithValue("@Query",3);
                con.Open();
                result = com.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return result = 0;
            }
            finally
            {
                con.Close();
            }
        }

        //User/Update the order details

        public string UpdateOrder(OrderModel objorder)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ToString());
                SqlCommand com = new SqlCommand("Order1", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@OrderId", objorder.OrderId);
                com.Parameters.AddWithValue("@Name", objorder.Name);
                com.Parameters.AddWithValue("@Address", objorder.Address);
                com.Parameters.AddWithValue("@PhoneNumber", objorder.PhoneNumber);
                com.Parameters.AddWithValue("@ProductName", objorder.ProductName);
                com.Parameters.AddWithValue("@Description", objorder.Description);
                com.Parameters.AddWithValue("@Quantity", objorder.Quantity);
                com.Parameters.AddWithValue("@Query", 4);
                con.Open();
                result = com.ExecuteScalar().ToString();
                return result;
            }

            catch
            {
                return result = "";

            }
            finally
            {
                con.Close();
            }

        }
        //User/To display the order by id
        public OrderModel SelectOrderbyID(String OrderId)
        {
            SqlConnection con = null;
            DataSet ds = null;
            OrderModel oobj = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ToString());
                SqlCommand com = new SqlCommand("Order1", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Query", 5);
                com.Parameters.AddWithValue("@OrderId", OrderId);
                com.Parameters.AddWithValue("@Name", null);
                com.Parameters.AddWithValue("@Address", null);
                com.Parameters.AddWithValue("@PhoneNumber", null);
                com.Parameters.AddWithValue("@ProductName", null);
                com.Parameters.AddWithValue("@Description", null);
                com.Parameters.AddWithValue("@Quantity", null);

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = com;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oobj = new OrderModel();
                    oobj.OrderId = Convert.ToInt32(ds.Tables[0].Rows[i]["OrderId"].ToString());
                    oobj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    oobj.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                    oobj.PhoneNumber = ds.Tables[0].Rows[i]["PhoneNumber"].ToString();
                    oobj.ProductName = ds.Tables[0].Rows[i]["ProductName"].ToString();
                    oobj.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                    oobj.Quantity = Convert.ToInt32(ds.Tables[0].Rows[i]["Quantity"].ToString());
                }
                return oobj;
            }
            catch
            {
                return oobj;
            }
            finally
            {
                con.Close();
            }
        }

        //public bool ApplyApproved(int OrderId)
        //{

        //        SqlConnection con = null;
        //        con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ToString());
        //        SqlCommand com = new SqlCommand("statusupdate", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@OrderId", OrderId);

        //        con.Open();
        //        int i = com.ExecuteNonQuery();
        //        con.Close();
        //        if (i >= 1)
        //        {
        //            return true;
        //        }
        //        else
        //        {

        //            return false;
        //        }

        //}
    }
}