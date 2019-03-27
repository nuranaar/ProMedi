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
	public class PatientsController : Controller
    {
        private ProMediContext db = new ProMediContext();

        // GET: Manage/Patients
        public ActionResult Index()
        {
            return View(db.Patients.ToList());
        }

        // GET: Manage/Patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Fullname,Photo,Feedback")] Patient patient, HttpPostedFileBase Photo)
        {
			if (Photo == null)
			{
				ModelState.AddModelError("Photo", "Please Select file");
			}
			else
			{
				patient.Photo = FileManager.Upload(Photo);
			}
			if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        // GET: Manage/Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Manage/Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Fullname,Photo,Feedback")] Patient patient, HttpPostedFileBase Photo)
        {
			if (Photo != null)
			{
				FileManager.Delete(patient.Photo);
				patient.Photo = FileManager.Upload(Photo);
			}
			if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: Manage/Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Manage/Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
