using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProMediMvc.ViewModels;

namespace ProMediMvc.Controllers
{
    public class BlogController : BaseController
    {
        // GET: Blog
        public ActionResult Index()
        {
			BlogVm model = new BlogVm()
			{
				Blogs = db.Blogs.OrderBy(b => b.Date).Take(4).ToList(),
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
			var blog = db.Blogs.Include("Doctor").FirstOrDefault(b=> b.Slug == Slug);

			if (blog == null)
			{
				return HttpNotFound();
			}
			return View(blog);
		}
    }
}