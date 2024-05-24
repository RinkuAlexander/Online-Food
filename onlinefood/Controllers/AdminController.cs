using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using onlinefood.Repository;
using onlinefood.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.IO;

namespace onlinefood.Controllers
{
    public class AdminController : Controller
    {

       
        // GET: Admin/Get Category
        public ActionResult UploadFile()
        {
            return View();
        }
       
       //Poat: Admin/ Post Category
        [HttpPost]
        public ActionResult UploadFile(CateModel objcart, HttpPostedFileBase file)
        {
           
            string mainconn = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection con = new SqlConnection(mainconn);
            SqlCommand com = new SqlCommand("Cate", con);
            con.Open();
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Query", 1);
            com.Parameters.AddWithValue("@Name", objcart.Name);
                if(file != null && file.ContentLength>0)
                 {
                    string filename = Path.GetFileName(file.FileName);
                    string imgpath = Path.Combine(Server.MapPath("~/UploadedFiles/"), filename);
                    file.SaveAs(imgpath);
                 }
            com.Parameters.AddWithValue("@Image","~/UploadedFiles/" + file.FileName);
            com.ExecuteNonQuery();
            con.Close();
            ViewData["Message"] = "User record" + objcart.Name + "Is saved Successfully";
            return View();
         }

        //Get: Admin/ To displaythe category
        [HttpGet]
        public ActionResult ShowCategories()
        {
            Admin adRepo = new Admin();
            ModelState.Clear();
            return View(adRepo.GetCategories());
        }
        
        //Get: Admin/Delete the category
        [HttpGet]
        public ActionResult DeleteCategories(String Id)
        {
            Admin obj = new Admin();
            int result = obj.DeleteCategories(Id);
            TempData["result2"] = result;
            ModelState.Clear();
            return RedirectToAction("ShowCategories");

        }

        //Get: Admin/Delete products
        [HttpGet]
        public ActionResult DeleteProducts(String ProductId)
        {
            Admin adRepo = new Admin();
            int result = adRepo.DeleteProducts(ProductId);
            TempData["result4"] = result;
            ModelState.Clear();
            return RedirectToAction("ShowProductsDetails");

        }

        //Get: Admin/Add products
        public ActionResult AddProductDetails()
        {
            return View();
        }

        
        //Post: Admin/Add product details
        [HttpPost]
        public ActionResult AddProductDetails(ProductModel objPro, HttpPostedFileBase file)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection con = new SqlConnection(mainconn);
            SqlCommand com = new SqlCommand("Products", con);
            con.Open();
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Query", 1);
            com.Parameters.AddWithValue("@Name", objPro.Name);
            com.Parameters.AddWithValue("@Description", objPro.Description);
            com.Parameters.AddWithValue("@Price", objPro.Price);
            com.Parameters.AddWithValue("@Quantity", objPro.Quantity);
            if (file != null && file.ContentLength > 0)
            {
                string filename = Path.GetFileName(file.FileName);
                string imgpath = Path.Combine(Server.MapPath("~/UploadedFiles/"), filename);
                file.SaveAs(imgpath);
            }
            com.Parameters.AddWithValue("@Image", "~/UploadedFiles/" + file.FileName);
            com.ExecuteNonQuery();
            con.Close();
            ViewData["Message"] = "User record" + objPro.Name + "Is saved Successfully";
            return View();
        }

        //Get: Admin/ To display the products
        [HttpGet]
        public ActionResult ShowProductsDetails()
        {
            Admin adRepo = new Admin();
            ModelState.Clear();
            return View(adRepo.GetProducts());
        }

        //Get: Admin/ User can view the products
        [HttpGet]
        public ActionResult UserProductsDetails()
        {
            Admin adRepo = new Admin();
            ModelState.Clear();
            return View(adRepo.GetProducts());
        }

        //Get: Admin/ Update the product

        [HttpGet]
        public ActionResult UpdateProduct(string ProductId)
        {
            Admin adRepo = new Admin();
            ProductModel proobj = new ProductModel();
            return View(adRepo.SelectDatabyID(ProductId));
        }

        [HttpPost]
        public ActionResult UpdateProduct(ProductModel proobj)
        {

            if (ModelState.IsValid) //checking model is valid or not    
            {
                Admin adRepo = new Admin(); //calling class DBdata    
                string result = adRepo.UpdateProduct(proobj);
                TempData["result3"] = result;
                ModelState.Clear(); //clearing model   
                return RedirectToAction("ShowProductsDetails");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

    }
}
