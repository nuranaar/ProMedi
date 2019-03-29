using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProMediMvc.Controllers
{
    public class AppointmentController : BaseController
    {
        // GET: Appointment
        public ActionResult Index()
        {
			ViewBag.Set = db.Settings.FirstOrDefault();
			ViewBag.Deps = db.Departments.ToList();
			ViewBag.Docs = db.Doctors.ToList();
            return View();
        }
		public JsonResult Message(string name, string email, string number, string depart, string doctor, string date, string message)
		{
			if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(message) || string.IsNullOrEmpty(doctor)|| date==null)
			{
				Response.StatusCode = 406;
				return Json("Name, Email, Doctor, Date  and Message is required", JsonRequestBehavior.AllowGet);
			}
			var body = "<ul><li>Name : {0}</li><li>Email : {1}</li><li>Phone : {2}</li><li>Department : {3}</li><li>Doctor : {4}</li><li>Date : {5}</li></ul><p>{6}</p>";
			var MailMessage = new MailMessage();
			MailMessage.To.Add(new MailAddress("nuranaar@code.edu.az"));
			MailMessage.From = new MailAddress(email);
			MailMessage.Subject = "Your email subject";
			MailMessage.Body = string.Format(body, name, email, number, depart, doctor, date, message);
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
					Password = ""
				}
			};
			client.Send(MailMessage);

			return Json("Message send!", JsonRequestBehavior.AllowGet);
		}
	}
}