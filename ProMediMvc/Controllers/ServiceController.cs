using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProMediMvc.Controllers
{
    public class ServiceController : BaseController
    {
        // GET: Service
        public ActionResult Index()
        {
			ViewBag.Services = db.Services.ToList();
            return View();
        }
    }
}