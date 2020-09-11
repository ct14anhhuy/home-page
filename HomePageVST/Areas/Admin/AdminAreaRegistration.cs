using System.Web.Mvc;

namespace HomePageVST.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
               name: "Login",
               url: "login.html",
               defaults: new { controller = "UserLogin", action = "Login" },
               namespaces: new string[] { "HomePageVST.Areas.Admin.Controllers" });

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}