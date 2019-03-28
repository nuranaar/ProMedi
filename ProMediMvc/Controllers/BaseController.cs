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
			ViewBag.Setting = db.Settings.FirstOrDefault();
			ViewBag.Department = db.Departments.ToList();
			ViewBag.DocList = db.Doctors.ToList();
			ViewBag.Spesiality = db.Specialities.ToList();
			ViewBag.Tags = db.BlogTags.ToList();
			ViewBag.Cats = db.BlogCats.ToList();
			ViewBag.BlogList = db.Blogs.Include("Doctor").OrderByDescending(b => b.Date).Take(4).ToList();
		}

    }
}