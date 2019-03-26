using System.Web.Mvc;

namespace ProMediMvc.Areas.Manage
{
    public class ManageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Manage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Manage_default",
                "manage/{controller}/{action}/{id}",
                new {  action = "Index", id = UrlParameter.Optional },
				new[] { "ProMediMvc.Areas.Manage.Controllers" }
			);
        }
    }
}