using Learning_collection.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learning_collection.Controllers
{
    public class MyAccountController : Controller
    {
        // GET: MyAccount
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return RedirectToAction("DataInsert", "Database");
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {

            /*****string******/
            string command = "select * from Logins where Firstname='";
            command += collection["Firstname"];
            command += "'";
            /*****************/
            SqlDataReader dr = null;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ASPNET\Learning_collection\Learning_collection\App_Data\DataBase1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(command, conn);

            bool error = false;
            Package P = new Package();
            P.Id = new List<int>();
            P.Firstname = new List<string>();
            P.Lastname = new List<string>();
            P.Email = new List<string>();
            try
            {
                // open the connection
                conn.Open();

                // 1. get an instance of the SqlDataReader
                dr = cmd.ExecuteReader();

                // 2. print necessary columns of each record
                if (dr.Read())
                {
                    int id = (int)dr["Id"];
                    string Firstname = (string)dr["Firstname"];
                    string Lastname = (string)dr["Lastname"];
                    string Email = (string)dr["Email"];

                    P.Id.Add(id);
                    P.Firstname.Add(Firstname);
                    P.Lastname.Add(Lastname);
                    P.Email.Add(Email);
                    if (Email == collection["Email"])
                    {
                        Session["user"] = collection["Firstname"];
                        if (collection["RememberMe"] != null)
                        {
                            HttpCookie ckUsername = new HttpCookie("username");
                            ckUsername.Expires = DateTime.Now.AddDays(1d);
                            ckUsername.Value = collection["Firstname"];
                            Response.Cookies.Add(ckUsername);
                        }
                        
                    }
                    else
                    {
                        ViewData["Error"] = "Error Email";
                        error = true;
                    }

                }else
                {
                    ViewData["Error"] = "This name doesn't exist!";
                    error = true;
                }
            }
            finally
            {
                // 3. close the reader
                if (dr != null)
                {
                    dr.Close();
                }

                // close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            if (error)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        public ActionResult Logout()
        {
            Session.Remove("user");
            if(Response.Cookies["username"]!= null)
            {
                HttpCookie ckUsername = new HttpCookie("username");
                ckUsername.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(ckUsername);
            }  
            return RedirectToAction("Login","MyAccount");
        }
    }
}