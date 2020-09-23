using System.Web.Mvc;
using System.Web.Optimization;

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

            RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css/admin")
                .Include("~/Content/themes/bootstrap-3.2.0/css/bootstrap.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/themes/DataTables/css/jquery.dataTables.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/themes/base/jquery-ui.css", new CssRewriteUrlTransform()));

            bundles.Add(new Bundle("~/js/admin").Include(
                "~/assets/Scripts/jquery-1.12.4.min.js",
                "~/Content/themes/jquery-ui-1.12.1/jquery-ui.min.js",
                "~/Content/themes/DataTables/js/jquery.dataTables.min.js",
                "~/Content/themes/ckeditor/ckeditor.js"
               ));
            
            BundleConfig.RegisterBundles(bundles);
        }
    }
}