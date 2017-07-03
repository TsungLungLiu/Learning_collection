using Learning_collection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Learning_collection.Controllers
{
    public class SendEmailController : Controller
    {
        // GET: SendEmail
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home  
        public ActionResult SendEmail()
        {

            return View();
        }
        public ActionResult SendEmail_2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendEmail_2(FormCollection collection)
        {

            try
            {
                //Configuring webMail class to send emails  
                //gmail smtp server  
                WebMail.SmtpServer = "smtp.gmail.com";
                //gmail port to send emails  
                WebMail.SmtpPort = 587;
                WebMail.SmtpUseDefaultCredentials = true;
                //sending emails with secure protocol  
                WebMail.EnableSsl = true;
                //EmailId used to send emails from application  
                WebMail.UserName = "j5877758777@gmail.com";
                WebMail.Password = "j807807807";

                //Sender email address.  
                WebMail.From = "j5877758777@gmail.com";

                //Send email  
                WebMail.Send(to: collection["toemail"], subject: collection["subject"], body: collection["body"], isBodyHtml: true);
                ViewBag.Status = "Email Sent Successfully.";
            }
            catch (Exception e)
            {
                ViewBag.Status = "Problem while sending email, Please check details.";

            }


            return View();
        }


        [HttpPost]
        public ActionResult SendEmail(EmployeeModel obj)
        {

            try
            {
                //Configuring webMail class to send emails  
                //gmail smtp server  
                WebMail.SmtpServer = "smtp.gmail.com";
                //gmail port to send emails  
                WebMail.SmtpPort = 587;
                WebMail.SmtpUseDefaultCredentials = true;
                //sending emails with secure protocol  
                WebMail.EnableSsl = true;
                //EmailId used to send emails from application  
                WebMail.UserName = "j5877758777@gmail.com";
                WebMail.Password = "j807807807";

                //Sender email address.  
                WebMail.From = "j5877758777@gmail.com";

                //Send email  
                WebMail.Send(to: obj.ToEmail, subject: obj.EmailSubject, body: obj.EMailBody, cc: obj.EmailCC, bcc: obj.EmailBCC, isBodyHtml: true);

                ViewBag.Status = "Email Sent Successfully.";
            }
            catch (Exception e)
            {
                ViewBag.Status = "Problem while sending email, Please check details.";

            }
            return View();
        }

    }
}