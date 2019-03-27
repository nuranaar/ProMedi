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
	public class BlogTagsController : Controller
    {
		private ProMediContext db = new ProMediContext();

        // GET: Manage/BlogTags
        public ActionResult Index()
        {
            return View(db.BlogTags.ToList());
        }

        // GET: Manage/BlogTags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/BlogTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] BlogTag blogTag)
        {
            if (ModelState.IsValid)
            {
                db.BlogTags.Add(blogTag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogTag);
        }

        // GET: Manage/BlogTags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogTag blogTag = db.BlogTags.Find(id);
            if (blogTag == null)
            {
                return HttpNotFound();
            }
            return View(blogTag);
        }

        // POST: Manage/BlogTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] BlogTag blogTag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogTag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogTag);
        }

        // GET: Manage/BlogTags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogTag blogTag = db.BlogTags.Find(id);
            if (blogTag == null)
            {
                return HttpNotFound();
            }
            return View(blogTag);
        }

        // POST: Manage/BlogTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogTag blogTag = db.BlogTags.Find(id);
            db.BlogTags.Remove(blogTag);
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
