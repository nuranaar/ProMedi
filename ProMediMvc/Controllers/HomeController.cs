using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProMediMvc.DAL;
using ProMediMvc.ViewModels;

namespace ProMediMvc.Controllers
{
    public class HomeController : BaseController
    {
		// GET: Home
		public ActionResult Index()
        {

			IndexVm model = new IndexVm()
			{
				Sliders = db.Sliders.ToList(),
				About = db.Abouts.Find(2),
				ProMedis = db.ProMedis.ToList(),
				Patients = db.Patients.ToList(),
				Departments = db.Departments.ToList(),
				Facts = db.Facts.ToList(),
				Blogs = db.Blogs.OrderBy(b => b.Date).Take(4).ToList()
			};

            return View(model);
        }
		public ActionResult Index2()
		{
			IndexVm model = new IndexVm()
			{
				Sliders = db.Sliders.ToList(),
				About = db.Abouts.Find(2),
				ProMedis = db.ProMedis.ToList(),
				Patients = db.Patients.ToList(),
				Departments = db.Departments.ToList(),
				Facts = db.Facts.ToList(),
				Blogs = db.Blogs.OrderBy(b => b.Date).Take(4).ToList()
			};
			ViewBag.Services = db.Services.ToList();
			return View(model);
		}
	}
}