using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProMediMvc
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.MapRoute(
				name: "DepartmentUrl",
				url: "{controller}/{action}/{*slug}",
				defaults: new { controller = "Department", action = "Detail", slug = UrlParameter.Optional }
			);
			routes.MapRoute(
				name: "DoctorUrl",
				url: "{controller}/{action}/{*slug}",
				defaults: new { controller = "Doctor", action = "Detail", slug = UrlParameter.Optional }
			);
			routes.MapRoute(
				name: "BlogUrl",
				url: "{controller}/{action}/{*slug}",
				defaults: new { controller = "Blog", action = "Detail", slug = UrlParameter.Optional }
			);
			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
				namespaces: new[] { "Hyna.Controllers" }

			);
		}
	}
}
