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



namespace onlinefood.Controllers
{
    public class UserSignUpController : Controller
    {
        //To connect with database
        private SqlConnection con;
        private string Connection()
        {

            string constr = ConfigurationManager.ConnectionStrings["myconn"].ToString();
            con = new SqlConnection(constr);
            return constr;
        }

        //Get:User/ Login page
        public ActionResult MyLogin()
        {
            Session["UserLogin"] = "false";
            Session["AdminLogin"] = "false";
            //return RedirectToAction("MyLogin");
            return View("MyLogin");
        }

        //Post: User/ Login 
        [HttpPost]
        public ActionResult MyLogin(UserSignup objuser)
        {
            Connection();
            // SqlCommand com = new SqlCommand("[dbo].[UserLogin]");
            string s = "select * from tbl_UserSignup where Username=@Username and Password=@Password";
            SqlCommand com = new SqlCommand(s,con);
            con.Open();
            //com.CommandType = CommandType.StoredProcedure;
            //com.CommandText = "[dbo].[UserLogin]";
            com.Parameters.AddWithValue("@Username", objuser.Username);
            com.Parameters.AddWithValue("@Password", objuser.Password);
            SqlDataReader rdr = com.ExecuteReader();
            if(rdr.Read())
            {
                if(objuser.Username=="Admin")
                {
                    Session["AdminLogin"] = "true";
                    return RedirectToAction("AdminPage");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(objuser.Username, true);
                    Session["Username"] = objuser.Username.ToString();
                   Session["UserLogin"] = "true";
                  
                    return RedirectToAction("UserPage");
                }
            }
            else
            {
                TempData["msg"] = "<script>alert('Username or Password is incorrect')</script>";
                Session["MyLogin"] = "false";
            }
            con.Close();
            return View();
        }

        //Get: User/ Adim page
        public ActionResult AdminPage()
        {
            return View();
        }

        //Get: User/ User page
        public ActionResult UserPage()
        {
            return View();
        }
       
        // GET: User/ user details

        [HttpGet]
        public ActionResult AddUserDetails()
        {
            return View();
        }

        //Post: User/ user details
        [HttpPost]
        public ActionResult AddUserDetails(UserSignup objuser)
        {
            objuser.DateofBirth = Convert.ToDateTime(objuser.DateofBirth);
            if(ModelState.IsValid)
            {
                User obj = new User();
                string result = obj.AddUserDetails(objuser);
                TempData["result1"] = result;
                ModelState.Clear();
                return RedirectToAction("MyLogin");

            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        //Get: User/ User can view the details
        [HttpGet]
        public ActionResult ShowUserDetails()
        {
            User obj = new User();
            ModelState.Clear();
            return View(obj.GetUserDetails());
        }

        //Get: User/ Admin can view the details
        public ActionResult AdminShowDetails()
        {
            User obj = new User();
            ModelState.Clear();
            return View(obj.GetUserDetails());
        }

        //Get: User/ User details
        [HttpGet]
        public ActionResult Details(string ID)
        {
            UserSignup objuser = new UserSignup();
            User obj = new User();
            return View(obj.SelectDatabyID(ID));
        }
        //Get: User/ User edit details
        [HttpGet]
        public ActionResult Edit(string ID)
        {
            User obj = new User();
            UserSignup objuser = new UserSignup();
            return View(obj.SelectDatabyID(ID));
        }


        //Post: User/ User can edit details
        [HttpPost]
        public ActionResult Edit(UserSignup objuser)
        {
            objuser.DateofBirth = Convert.ToDateTime(objuser.DateofBirth);
            if (ModelState.IsValid) //checking model is valid or not    
            {
                User obj = new User(); //calling class DBdata    
                string result = obj.UpdateData(objuser);
                TempData["result2"] = result;
                ModelState.Clear(); //clearing model    
                return RedirectToAction("ShowUserDetails");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }



        //Get: User/ Delete details
        [HttpGet]
        public ActionResult DeleteUserDetails(string ID)
        {
            User obj = new User();
            int result = obj.DeleteUserDetails(ID);
            TempData["result3"] = result;
            ModelState.Clear();
            return RedirectToAction("ShowUserDetails");
            
        }

        //Get: User/To display the products
        [HttpGet]
        public ActionResult ShowProductsDetails()
        {
            Connection();
            Admin adRepo = new Admin();
            ModelState.Clear();
            return View(adRepo.GetProducts());
        }

        //Get: User/ Order
        [HttpGet]
        public ActionResult AddOrder()
        {
            return View();
        }

        //Post: User/ Order
        [HttpPost]
        public ActionResult AddOrder(OrderModel objorder)
        {
            if (ModelState.IsValid)
            {
                User obj = new User();
                string result = obj.AddOrder(objorder);
                TempData["result1"] = result;
                ModelState.Clear();
                return RedirectToAction("ShowOrderDetails");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        //Get: User/ To view the order
        [HttpGet]
        public ActionResult ShowOrderDetails()
        {
            User obj = new User();
            ModelState.Clear();
            return View(obj.GetOrderDetails());
        }

        //Get: User/ Edit the order
        [HttpGet]
        public ActionResult Editdetails(string OrderId)
        {
            OrderModel objorder = new OrderModel();
            User obj = new User();
            return View(obj.SelectOrderbyID(OrderId));
           
        }

        //Post: User/Edit the order
        [HttpPost]
        public ActionResult Editdetails(OrderModel objorder,int OrderId)
        {
            
            if (ModelState.IsValid) //checking model is valid or not    
            {
                User obj = new User(); //calling class DBdata    
                string result = obj.UpdateOrder(objorder);
                TempData["result4"] = result;
                ModelState.Clear(); //clearing model    
                return RedirectToAction("ShowOrderDetails");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }



        //Get: User/ Delete the order
        [HttpGet]
        public ActionResult DeleteDetails(String OrderId)
        {
            User obj = new User();
            int result = obj.DeleteOrderDetails(OrderId);
            TempData["result3"] = result;
            ModelState.Clear();
            return RedirectToAction("ShowOrderDetails");

        }

    }
}
