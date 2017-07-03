using Learning_collection.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Learning_collection.Controllers
{
    public class DatabaseController : Controller
    {
        // GET: Database
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DataInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ASPNET\Learning_collection\Learning_collection\App_Data\DataBase1.mdf;Integrated Security=True");


                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into Logins(Firstname,Lastname,Email) values('" + collection["Firstname"] + "','" + collection["Lastname"] + "','" + collection["Email"] + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                //
                return RedirectToAction("DataInsert");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ActionResult ShowData_1()
        {
            SqlDataReader dr = null;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ASPNET\Learning_collection\Learning_collection\App_Data\DataBase1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from Logins", conn);

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
                while (dr.Read())
                {
                    // get the results of each column
                    int id = (int)dr["Id"];
                    string Firstname = (string)dr["Firstname"];
                    string Lastname = (string)dr["Lastname"];
                    string Email = (string)dr["Email"];

                    P.Id.Add(id);
                    P.Firstname.Add(Firstname);
                    P.Lastname.Add(Lastname);
                    P.Email.Add(Email);
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


            return View(P);
        }

        public ActionResult ShowData_2()
        {
            LoginContext Db = new LoginContext();//create objecct of context

            return View(Db.data.ToList());//pass list of student to view
            //thats it to solve our problem or task QQ
        }

        public ActionResult SearchByEmail(string command)
        {
            if (command == null)
            {
                return View();
            }
            else
            {
                SqlDataReader dr = null;
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ASPNET\Learning_collection\Learning_collection\App_Data\DataBase1.mdf;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(command, conn);

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
                    while (dr.Read())
                    {
                        // get the results of each column
                        int id = (int)dr["Id"];
                        string Firstname = (string)dr["Firstname"];
                        string Lastname = (string)dr["Lastname"];
                        string Email = (string)dr["Email"];

                        P.Id.Add(id);
                        P.Firstname.Add(Firstname);
                        P.Lastname.Add(Lastname);
                        P.Email.Add(Email);
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
                ViewData["show"] = true;
                return View(P);
            }

        }

        public ActionResult Get_email(FormCollection collection)
        {
            /*****string******/
            string command = "select * from Logins where Email='";
            command += collection["Email"];
            command += "'";
            //ViewData["show"] = true;
            /*****************/
            return RedirectToAction("SearchByEmail", new { command });//
        }

        public ActionResult partialview()
        {
            return View();
        }

        public ActionResult GetData(string table, string value)
        {
            string command = "select * from Logins where ";
            command += table;
            command += "='";
            command += value;
            command += "'";

            SqlDataReader dr = null;
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["LoginContext"].ConnectionString);
            SqlCommand cmd = new SqlCommand(command, conn);

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
                while (dr.Read())
                {
                    // get the results of each column
                    int id = (int)dr["Id"];
                    string Firstname = (string)dr["Firstname"];
                    string Lastname = (string)dr["Lastname"];
                    string Email = (string)dr["Email"];

                    P.Id.Add(id);
                    P.Firstname.Add(Firstname);
                    P.Lastname.Add(Lastname);
                    P.Email.Add(Email);
                }
            }
            catch(Exception e)
            {

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



            return PartialView("_partialdata", P);
        }
    }
}