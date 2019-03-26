using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProMediMvc.DAL;
using ProMediMvc.Areas.Manage.Models;
using System.Web.Helpers;

namespace ProMediMvc.Areas.Manage.Controllers
{
    public class LoginController : Controller
    {
		private readonly ProMediContext db = new ProMediContext();
        // GET: Manage/Login
        public ActionResult Index()
        {
			if (Session["AdminLogin"] != null)
			{
				return RedirectToAction("index, dashboard");
			}
            return View();
        }
		public ActionResult Login(Admin admin)
		{
			if (string.IsNullOrEmpty(admin.Email) || string.IsNullOrEmpty(admin.Password))
			{
				Session["LoginError"] = "Email and password must fill";
				return RedirectToAction("index");
			}
			Admin adm = db.Admins.FirstOrDefault(a => a.Email == admin.Email);
			if (adm != null)
			{
				if(Crypto.VerifyHashedPassword(adm.Password, admin.Password))
				{
					Session["AdminLogin"] = true;
					Session["Admin"] = adm;
					return RedirectToAction("index, dashboard");
				}
			}
			Session["LoginError"] = "Email or password incorrects";
			return RedirectToAction("index");
		}
		
    }
}