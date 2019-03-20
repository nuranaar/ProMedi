using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProMediMvc.ViewModels;

namespace ProMediMvc.Controllers
{
    public class DepartmentController : BaseController
    {
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult Detail(string Slug)
		{
			if (string.IsNullOrEmpty(Slug))
			{
				return HttpNotFound();
			}
			DepartmentVm model = new DepartmentVm()
			{
				Department= db.Departments.FirstOrDefault(d => d.Slug == Slug)
			};

			model.Doctor = db.Doctors.FirstOrDefault(d => d.DepartmentId == model.Department.Id);
			model.Speciality = db.Specialities.FirstOrDefault(s => s.DepartmentId == model.Department.Id);

			if (model == null)
			{
				return HttpNotFound();
			}
			return View(model);
		}
	}
}