using System.Web.Optimization;
using Utilities;

namespace HomePageVST
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region ScriptBundle
            bundles.Add(new ScriptBundle("~/js/plugins").Include(
                "~/Scripts/jquery.js",
                "~/Content/themes/bootstrap-3.2.0/js/bootstrap.min.js",
                "~/Scripts/owl.carousel.min.js",
                "~/Scripts/jquery.stellar.min.js",
                "~/Scripts/jquery.sticky.js",
                "~/Scripts/jquery.stellar.min.js",
                "~/Scripts/wow.min.js",
                "~/Scripts/smoothscroll.js",
                "~/Scripts/lightbox.min.js"));

            bundles.Add(new ScriptBundle("~/js/customs").Include(
                "~/Scripts/scripts.js",
                "~/Scripts/left-menu.js",
                "~/Scripts/custom.js",
                "~/Scripts/dialog.js"));

            bundles.Add(new ScriptBundle("~/js/jquery.lazy").Include(
                "~/Content/themes/jquery.lazy/jquery.lazy.min.js"));

            #endregion

            #region StyleBundle
            bundles.Add(new StyleBundle("~/css/base")
             .Include("~/Content/themes/bootstrap-3.2.0/css/bootstrap.min.css", new CssRewriteUrlTransform())
             .Include("~/css/font-awesome.min.css", new CssRewriteUrlTransform())
             .Include("~/css/animate.css", new CssRewriteUrlTransform())
             .Include("~/css/owl.carousel.css", new CssRewriteUrlTransform())
             .Include("~/css/owl.theme.default.min.css", new CssRewriteUrlTransform())
             .Include("~/css/style.css", new CssRewriteUrlTransform())
             .Include("~/css/colors1.css", new CssRewriteUrlTransform())
             .Include("~/css/tooplate-style.css", new CssRewriteUrlTransform())
             .Include("~/css/lightbox.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/css/customs")
               .Include("~/css/customs.css", new CssRewriteUrlTransform())
               .Include("~/css/left-menu.css", new CssRewriteUrlTransform())
               .Include("~/css/dialog.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/css/home")
               .Include("~/css/home.css", new CssRewriteUrlTransform()));
            #endregion

            //BundleTable.EnableOptimizations = bool.Parse(ConfigHelper.ReadSetting("EnableBundles"));
        }
    }
}