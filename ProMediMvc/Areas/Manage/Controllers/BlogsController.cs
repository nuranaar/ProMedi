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
	public class BlogsController : Controller
    {
        private ProMediContext db = new ProMediContext();

        // GET: Manage/Blogs
        public ActionResult Index()
        {
            var blogs = db.Blogs.Include(b => b.BlogCat).Include(b => b.BlogTag).Include(b => b.Doctor);
            return View(blogs.ToList());
        }

        // GET: Manage/Blogs/Create
        public ActionResult Create()
        {
            ViewBag.BlogCatId = new SelectList(db.BlogCats, "Id", "Name");
            ViewBag.BlogTagId = new SelectList(db.BlogTags, "Id", "Name");
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "Name");
            return View();
        }

        // POST: Manage/Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Title,Photo,Decs,Date,Text,Slug,DoctorId,BlogCatId,BlogTagId")] Blog blog, HttpPostedFileBase Photo)
        {
			if (Photo == null)
			{
				ModelState.AddModelError("Photo", "Please Select file");
			}
			else
			{
				blog.Photo = FileManager.Upload(Photo);
			}
			if (ModelState.IsValid)
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BlogCatId = new SelectList(db.BlogCats, "Id", "Name", blog.BlogCatId);
            ViewBag.BlogTagId = new SelectList(db.BlogTags, "Id", "Name", blog.BlogTagId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "Name", blog.DoctorId);
            return View(blog);
        }

        // GET: Manage/Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlogCatId = new SelectList(db.BlogCats, "Id", "Name", blog.BlogCatId);
            ViewBag.BlogTagId = new SelectList(db.BlogTags, "Id", "Name", blog.BlogTagId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "Name", blog.DoctorId);
            return View(blog);
        }

        // POST: Manage/Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Edit([Bind(Include = "Id,Title,Photo,Decs,Date,Text,Slug,DoctorId,BlogCatId,BlogTagId")] Blog blog, HttpPostedFileBase Photo)
        {

			if (Photo != null)
			{
				FileManager.Delete(blog.Photo);
				blog.Photo = FileManager.Upload(Photo);
			}
			if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BlogCatId = new SelectList(db.BlogCats, "Id", "Name", blog.BlogCatId);
            ViewBag.BlogTagId = new SelectList(db.BlogTags, "Id", "Name", blog.BlogTagId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "Name", blog.DoctorId);
            return View(blog);
        }

        // GET: Manage/Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Manage/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
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
