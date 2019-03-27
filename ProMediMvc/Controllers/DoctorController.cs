using ProMediMvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProMediMvc.Controllers
{
    public class DoctorController : BaseController
    {
        // GET: Doctor
        public ActionResult Index()
        {
			ViewBag.DocList = db.Doctors.ToList();
			ViewBag.Spesiality = db.Specialities.ToList();
			return View();
        }
		public ActionResult Detail(string Slug)
		{
			if (string.IsNullOrEmpty(Slug))
			{
				return HttpNotFound();
			}
			DoctorVm model = new DoctorVm()
			{
				Doctor = db.Doctors.Include("Department").FirstOrDefault(d => d.Slug == Slug)
			};

			model.Speciality = db.Specialities.FirstOrDefault(s => s.DepartmentId == model.Doctor.DepartmentId);
			model.SpecExperts = db.SpecExperts.Include("Expert").Where(se => se.SpecialityId == model.Speciality.Id).ToList();
			if (model == null)
			{
				return HttpNotFound();
			}
			return View(model);
		}
	}
}