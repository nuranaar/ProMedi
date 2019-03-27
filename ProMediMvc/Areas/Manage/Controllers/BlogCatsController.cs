using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hyna.Areas.Manage.Filters;
using ProMediMvc.DAL;
using ProMediMvc.Models;

namespace ProMediMvc.Areas.Manage.Controllers
{
	[Auth]
	public class BlogCatsController : Controller
    {
        private ProMediContext db = new ProMediContext();

        // GET: Manage/BlogCats
        public ActionResult Index()
        {
            return View(db.BlogCats.ToList());
        }

        // GET: Manage/BlogCats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/BlogCats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] BlogCat blogCat)
        {
            if (ModelState.IsValid)
            {
                db.BlogCats.Add(blogCat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogCat);
        }

        // GET: Manage/BlogCats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogCat blogCat = db.BlogCats.Find(id);
            if (blogCat == null)
            {
                return HttpNotFound();
            }
            return View(blogCat);
        }

        // POST: Manage/BlogCats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] BlogCat blogCat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogCat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogCat);
        }

        // GET: Manage/BlogCats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogCat blogCat = db.BlogCats.Find(id);
            if (blogCat == null)
            {
                return HttpNotFound();
            }
            return View(blogCat);
        }

        // POST: Manage/BlogCats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogCat blogCat = db.BlogCats.Find(id);
            db.BlogCats.Remove(blogCat);
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
