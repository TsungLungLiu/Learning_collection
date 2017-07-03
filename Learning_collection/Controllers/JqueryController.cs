using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learning_collection.Controllers
{
    public class JqueryController : Controller
    {
        // GET: Jquery
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Simple()
        {
            return View();
        }
        
        public ContentResult GetData()
        {
            ContentResult content = new ContentResult();
            content.Content = "{\"name\":\"aaron\"}";
            content.ContentType = "application/json";

            return content;
        }

    }
}