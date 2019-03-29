using System.Web;
using System.Web.Optimization;

namespace ProMediMvc
{
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/js").Include(
					"~/Public/js/jquery.min.js",
					"~/Public/js/popper.min.js",
					"~/Public/js/bootstrap.min.js",
					"~/Public/js/owl.carousel.min.js",
					"~/Public/js/jquery.magnific-popup.min.js",
					"~/Public/js/waypoints.min.js",
					"~/Public/js/jquery.counterup.min.js",
					"~/Public/js/jquery.ui.js",
					"~/Public/js/jquery.ajaxchimp.min.js",
					"~/Public/js/form-validator.min.js",
					"~/Public/js/contact-form-script.js",
					"~/Public/js/appointment-form-script.js",
					"~/Public/js/promedi-map.js",
					"~/Public/js/script.js"));



			bundles.Add(new StyleBundle("~/bundles/css").Include(
					"~/Public/css/bootstrap.min.css",
					"~/Public/css/icofont.min.css",
					"~/Public/css/owl.carousel.min.css",
					"~/Public/css/owl.theme.default.min.css",
					"~/Public/css/animate.min.css",
					"~/Public/css/magnific-popup.css",
					"~/Public/css/jquery.ui.css",
					"~/Public/css/style.css",
					"~/Public/css/responsive.css"));
		}
	}
}
