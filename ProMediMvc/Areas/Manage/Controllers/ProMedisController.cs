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
	public class ProMedisController : Controller
    {
		
		private ProMediContext db = new ProMediContext();

        // GET: Manage/ProMedis
        public ActionResult Index()
        {
            return View(db.ProMedis.ToList());
        }

        // GET: Manage/ProMedis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/ProMedis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Icon,Title,Desc,Photo")] ProMedi proMedi, HttpPostedFileBase Photo)
        {
			if (Photo == null)
			{
				ModelState.AddModelError("Photo", "Please Select file");
			}
			else
			{
				proMedi.Photo = FileManager.Upload(Photo);
			}
			if (ModelState.IsValid)
            {
                db.ProMedis.Add(proMedi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proMedi);
        }

        // GET: Manage/ProMedis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProMedi proMedi = db.ProMedis.Find(id);
            if (proMedi == null)
            {
                return HttpNotFound();
            }
            return View(proMedi);
        }

        // POST: Manage/ProMedis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Icon,Title,Desc,Photo")] ProMedi proMedi, HttpPostedFileBase Photo)
        {
			if (Photo != null)
			{
				FileManager.Delete(proMedi.Photo);
				proMedi.Photo = FileManager.Upload(Photo);
			}
			if (ModelState.IsValid)
            {
                db.Entry(proMedi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proMedi);
        }

        // GET: Manage/ProMedis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProMedi proMedi = db.ProMedis.Find(id);
            if (proMedi == null)
            {
                return HttpNotFound();
            }
            return View(proMedi);
        }

        // POST: Manage/ProMedis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProMedi proMedi = db.ProMedis.Find(id);
            db.ProMedis.Remove(proMedi);
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
