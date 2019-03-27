using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hyna.Areas.Manage.Filters;
using ProMediMvc.Areas.Manage.Helpers;
using ProMediMvc.DAL;
using ProMediMvc.Models;

namespace ProMediMvc.Areas.Manage.Controllers
{
	[Auth]
	public class DoctorsController : Controller
    {
        private ProMediContext db = new ProMediContext();

        // GET: Manage/Doctors
        public ActionResult Index()
        {
            var doctors = db.Doctors.Include(d => d.Department);
            return View(doctors.ToList());
        }

        // GET: Manage/Doctors/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            return View();
        }

        // POST: Manage/Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Name,Surname,Phone,Degree,Photo,Desc,Text,Slug,DepartmentId")] Doctor doctor, HttpPostedFileBase Photo)
        {
			if (Photo == null)
			{
				ModelState.AddModelError("Photo", "Please Select file");
			}
			else
			{
				doctor.Photo = FileManager.Upload(Photo);
			}
			if (ModelState.IsValid)
            {
                db.Doctors.Add(doctor);
				doctor.Slug = (doctor.Name+"-" + doctor.Surname).ToLower();
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", doctor.DepartmentId);
            return View(doctor);
        }

        // GET: Manage/Doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", doctor.DepartmentId);
            return View(doctor);
        }

        // POST: Manage/Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Edit([Bind(Include = "Id,Name,Surname,Phone,Degree,Photo,Desc,Text,Slug,DepartmentId")] Doctor doctor, HttpPostedFileBase Photo)
        {
			if (Photo != null)
			{
				FileManager.Delete(doctor.Photo);
				doctor.Photo = FileManager.Upload(Photo);
			}
			if (ModelState.IsValid)
            {
				db.Entry(doctor).State = EntityState.Modified;
				db.SaveChanges();
                return RedirectToAction("Index");
            }
			ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", doctor.DepartmentId);
            return View(doctor);
        }

        // GET: Manage/Doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
			return View(doctor);
        }

        // POST: Manage/Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
