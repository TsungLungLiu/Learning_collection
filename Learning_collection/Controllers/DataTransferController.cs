using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Learning_collection.Models;
using Learning_collection.ViewModel;

namespace Learning_collection.Controllers
{
    public class DataTransferController : Controller
    {
        // GET: DataTransfer
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Tempdata()
        {
            ViewBag.Message = "If TempData is not null.Time will show at below.Click the AddTempData";
            if (TempData["time"] != null)
            {
                DateTime Time = (DateTime)TempData["Time"];
                ViewBag.time = Time.ToString();
            }
            return View();
        }

        public ActionResult AddTempData()
        {
            TempData["Time"] = DateTime.Now;
            return RedirectToAction("Tempdata");
        }

        public ActionResult ViewDataBag()
        {
            //PS:ViewData和ViewBag內的資料都是透過Key/Value的方法來存取，
            //但請注意在同個頁面中他們的key值還是不能重複，否則將會出現問題。
            
            //正確版
            ViewData["Hello"] = "Hello World";
            ViewBag.MVC = "Hello MVC"; // ViewBag 使用的動態產生的屬性

            //問題版-重複key值
            ViewData["Error"] = "Error 1";
            ViewBag.Error = "Error 2";

            return View();
        }

        public ActionResult Random() //ActionResult can be change to ViewResult
        {
            var movie = new Movie() { Name = "Sherk!" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1" },
                new Customer {Name = "Customer 2" }
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };


            return View(viewModel);
        }
    }
}