using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProMediMvc.DAL;
using ProMediMvc.ViewModels;

namespace ProMediMvc.Controllers
{
    public class AboutController : BaseController
    {
        // GET: About
        public ActionResult Index()
        {
			AboutVm model = new AboutVm()
			{
				About = db.Abouts.Find(1),
				Patients = db.Patients.ToList(),
				Facts = db.Facts.ToList(),
				Doctors = db.Doctors.ToList(),
				ProMedis = db.ProMedis.ToList(),
				Specialities = db.Specialities.ToList()
			};
            return View(model);
        }
    }
}