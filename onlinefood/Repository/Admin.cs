using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using onlinefood.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web.Mvc;

namespace onlinefood.Repository
{
    public class Admin
    {
        //get user details
        private SqlConnection con;

        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["myconn"].ToString();
            con = new SqlConnection(constr);
            
        }
        //Admin /To get details of the category
        public List<CateModel> GetCategories()
        {
            connection();
            List<CateModel> Categorieslist = new List<CateModel>();
            SqlCommand com = new SqlCommand("Cate", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Query", 3);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
                Categorieslist.Add(
                    new CateModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Image = Convert.ToString(dr["Image"]),
                    }
                    );
            return Categorieslist;
        }


        //Admin /To delete the category
        public int DeleteCategories(String Id)
        {
            SqlConnection con = null;
            int result;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ToString());
                SqlCommand com = new SqlCommand("Cate", con);
                com.CommandType = CommandType.StoredProcedure;
                con.Open();
                com.Parameters.AddWithValue("@Query", 2);
                com.Parameters.AddWithValue("@Id", Id);
                com.Parameters.AddWithValue("@Name", null);
                com.Parameters.AddWithValue("@Image", null);
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
        //Admin /To delete the products
        public int DeleteProducts(String ProductId)
        {
            SqlConnection con = null;
            int result;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ToString());
                SqlCommand com = new SqlCommand("Products", con);
                com.CommandType = CommandType.StoredProcedure;
                con.Open();
                com.Parameters.AddWithValue("@Query", 4);
                com.Parameters.AddWithValue("@ProductId", ProductId);
                com.Parameters.AddWithValue("@Name", null);
                com.Parameters.AddWithValue("@Description", null);
                com.Parameters.AddWithValue("@Price", null);
                com.Parameters.AddWithValue("@Quantity", null);
                com.Parameters.AddWithValue("@Image", null);
                
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
        //Admin/To get the Products

        public List<ProductModel> GetProducts()
        {
            connection();
            List<ProductModel> Productlist = new List<ProductModel>();
            SqlCommand com = new SqlCommand("Products", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Query", 2);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
                Productlist.Add(
                    new ProductModel
                    {
                        ProductId = Convert.ToInt32(dr["ProductId"]),
                        Name = Convert.ToString(dr["Name"]),
                        Description = Convert.ToString(dr["Description"]),
                        Price = Convert.ToString(dr["Price"]),
                        Quantity = Convert.ToInt32(dr["Quantity"]),
                        Image = Convert.ToString(dr["Image"]),
                    }
                    );
            return Productlist;
        }


        public List<ProductModel> GetProductDetail()
        {
            connection();
            List<ProductModel> Productlist = new List<ProductModel>();
            SqlCommand com = new SqlCommand("Products", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Query", 5);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind Bank generic list using dataRow
            foreach (DataRow dr in dt.Rows)
            {
                Productlist.Add(
                new ProductModel
                {
                    ProductId = Convert.ToInt32(dr["ProductId"]),
                    Name = Convert.ToString(dr["Name"]),
                    Description = Convert.ToString(dr["Description"]),
                    Price = Convert.ToString(dr["Price"]),
                    Quantity = Convert.ToInt32(dr["Quantity"]),
                    Image = Convert.ToString(dr["Image"])
                }
                );
            }
            return Productlist;
        }




        //Admin/Update the product
        //public bool UpdateProduct(ProductModel objpro)
        //{
        //    connection();
        //    SqlCommand com = new SqlCommand("Products", con);
        //    com.CommandType = CommandType.StoredProcedure;
        //    com.Parameters.AddWithValue("@Query", 3);
        //    com.Parameters.AddWithValue("@ProductId", objpro.ProductId);
        //    com.Parameters.AddWithValue("@Name", objpro.Name);
        //    com.Parameters.AddWithValue("@Description", objpro.Description);
        //    com.Parameters.AddWithValue("@Price", objpro.Price);
        //    com.Parameters.AddWithValue("@Quantity", objpro.Quantity);
        //    com.Parameters.AddWithValue("@Image", objpro.Image);
        //    con.Open();
        //    int i = com.ExecuteNonQuery();
        //   con.Close();
        //    if (i >= 1)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}





        public string UpdateProduct(ProductModel objpro)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ToString());
                SqlCommand com = new SqlCommand("Products", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Query", 3);
                com.Parameters.AddWithValue("@ProductId", objpro.ProductId);
                com.Parameters.AddWithValue("@Name", objpro.Name);
                com.Parameters.AddWithValue("@Description", objpro.Description);
                com.Parameters.AddWithValue("@Price", objpro.Price);
                com.Parameters.AddWithValue("@Quantity", objpro.Quantity);
                com.Parameters.AddWithValue("@Image", objpro.Image);
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

        public ProductModel SelectDatabyID(String ProductId)
        {
            SqlConnection con = null;
            DataSet ds = null;
            ProductModel proobj = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ToString());
                SqlCommand com = new SqlCommand("Products", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ProductId", ProductId);
                com.Parameters.AddWithValue("@Name", null);
                com.Parameters.AddWithValue("@Description", null);
                com.Parameters.AddWithValue("@Price", null);
                com.Parameters.AddWithValue("@Quantity", null);
                com.Parameters.AddWithValue("@Image", null);
                com.Parameters.AddWithValue("@Query", 5);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = com;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    proobj = new ProductModel();
                    proobj.ProductId = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductId"].ToString());
                    proobj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    proobj.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                    proobj.Price = ds.Tables[0].Rows[i]["Price"].ToString();
                    proobj.Quantity = Convert.ToInt32(ds.Tables[0].Rows[i]["Quantity"].ToString());
                    proobj.Image = ds.Tables[0].Rows[i]["Image"].ToString();

                }
                return proobj;
            }
            catch
            {
                return proobj;
            }
            finally
            {
                con.Close();
            }
        }

    }
}
     