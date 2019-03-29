using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProMediMvc.Models;
using ProMediMvc.ViewModels;

namespace ProMediMvc.Controllers
{
    public class BlogController : BaseController
    {
        // GET: Blog
        public ActionResult Index(int page=1)
        {
			BlogVm model = new BlogVm()
			{
				Blogs = db.Blogs.OrderBy(b => b.Date).Skip((page-1)*3).Take(4).ToList(),
				TotalPage=Convert.ToInt32(Math.Ceiling(db.Blogs.Count()/3.0)),
				Page=page,
				Tags = db.BlogTags.ToList(),
				Cats = db.BlogCats.ToList(),
				Doctors = db.Doctors.ToList()
			};
			return View(model);
        }

		public ActionResult Detail(string Slug)
		{
			if (string.IsNullOrEmpty(Slug))
			{
				return HttpNotFound();
			}
			var blog = db.Blogs.Include("Doctor").FirstOrDefault(b => b.Slug == Slug);

			List<Blog> blogs = db.Blogs.OrderByDescending(b => b.Id).ToList();

			int index = blogs.IndexOf(blog);

			if ((index + 1) < blogs.Count())
			{
				ViewBag.PrevBlog = blogs[index + 1];
			}
			if ((index - 1) >= 0)
			{
				ViewBag.NextBlog = blogs[index - 1];
			}

			if (blog == null)
			{
				return HttpNotFound();
			}

			return View(blog);
		}

    }
}