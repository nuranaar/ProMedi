using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProMediMvc.DAL;


namespace ProMediMvc.Controllers
{
    public class BaseController : Controller
    {
		protected readonly ProMediContext db = new ProMediContext();

		public BaseController()
		{
			ViewBag.Setting = db.Settings.First();
			ViewBag.Department = db.Departments.ToList();
		}

    }
}