using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProMediMvc.DAL;

namespace ProMediMvc.Controllers
{
    public class FAQController : BaseController
    {
		private readonly ProMediContext db = new ProMediContext();
        public ActionResult Index()
        {
			ViewBag.FAQ = db.Faqs.ToList();
            return View();
        }
    }
}