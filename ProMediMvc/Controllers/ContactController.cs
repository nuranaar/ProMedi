using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using ProMediMvc.DAL;

namespace ProMediMvc.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
		public JsonResult Message(string name, string email, string number, string subject, string message)
		{
			if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(message) || string.IsNullOrEmpty(number))
			{
				Response.StatusCode = 406;
				return Json("Name,Email,Number and Message is required", JsonRequestBehavior.AllowGet);
			}
			var body = "<ul><li>Name : {0}</li><li>Email : {1}</li><li>Phone : {2}</li><li>Subject : {3}</li></ul><p>{4}</p>";
			var MailMessage = new MailMessage();
			MailMessage.To.Add(new MailAddress("nuranaar@code.edu.az")); 
			MailMessage.From = new MailAddress(email);
			MailMessage.Subject = "Your email subject";
			MailMessage.Body = string.Format(body, name, email, number, subject, message);
			MailMessage.IsBodyHtml = true;
			SmtpClient client = new SmtpClient
			{
				Host = "smtp.gmail.com",
				Port = 587,
				EnableSsl = true,
				UseDefaultCredentials = false,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				Credentials = new NetworkCredential
				{
					UserName = "nuranaar@code.edu.az", 
					Password = "iphone600"
				}
			};

			client.Send(MailMessage);
			return Json("Message send!", JsonRequestBehavior.AllowGet);
		}
    }
}