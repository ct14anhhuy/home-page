using System.Web.Optimization;
using Utilities;
using StyleBundle = HomePageVST.Extensions.CustomBundles.StyleBundle;

namespace HomePageVST
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region ScriptBundle

            bundles.Add(new ScriptBundle("~/js/plugins").Include(
                "~/assets/Scripts/jquery.js",
                "~/Content/themes/bootstrap-3.2.0/js/bootstrap.min.js",
                "~/assets/Scripts/owl.carousel.min.js",
                "~/assets/Scripts/jquery.stellar.min.js",
                "~/assets/Scripts/jquery.sticky.js",
                "~/assets/Scripts/jquery.stellar.min.js",
                "~/assets/Scripts/wow.min.js",
                "~/assets/Scripts/smoothscroll.js",
                "~/assets/Scripts/lightbox.min.js"));

            bundles.Add(new ScriptBundle("~/js/customs").Include(
                "~/assets/Scripts/scripts.js",
                "~/assets/Scripts/left-menu.js",
                "~/assets/Scripts/custom.js",
                "~/assets/Scripts/dialog.js",
                "~/assets/Scripts/fix-width.js"));

            bundles.Add(new ScriptBundle("~/js/jquery.lazy").Include(
                "~/Content/themes/jquery.lazy/jquery.lazy.min.js"));

            bundles.Add(new ScriptBundle("~/js/home").Include(
                "~/assets/Scripts/home.js"));

            #endregion ScriptBundle

            #region StyleBundle

            bundles.Add(new StyleBundle("~/css/base")
             .Include("~/Content/themes/bootstrap-3.2.0/css/bootstrap.min.css", new CssRewriteUrlTransform())
             .Include("~/assets/css/font-awesome.min.css", new CssRewriteUrlTransform())
             .Include("~/assets/css/animate.css", new CssRewriteUrlTransform())
             .Include("~/assets/css/owl.carousel.css", new CssRewriteUrlTransform())
             .Include("~/assets/css/owl.theme.default.min.css", new CssRewriteUrlTransform())
             .Include("~/assets/css/style.css", new CssRewriteUrlTransform())
             .Include("~/assets/css/colors1.css", new CssRewriteUrlTransform())
             .Include("~/assets/css/tooplate-style.css", new CssRewriteUrlTransform())
             .Include("~/assets/css/lightbox.css", new CssRewriteUrlTransform())
             .Include("~/assets/css/themify-icons.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/css/customs")
               .Include("~/assets/css/customs.css", new CssRewriteUrlTransform())
               .Include("~/assets/css/left-menu.css", new CssRewriteUrlTransform())
               .Include("~/assets/css/dialog.css", new CssRewriteUrlTransform())
               .Include("~/assets/css/bootstrap-nonresponsive.css", new CssRewriteUrlTransform())
               .Include("~/assets/css/fix-width.css", new CssRewriteUrlTransform())
               );

            bundles.Add(new StyleBundle("~/css/home")
               .Include("~/assets/css/home.css", new CssRewriteUrlTransform()));

            #endregion StyleBundle

            BundleTable.EnableOptimizations = bool.Parse(ConfigHelper.ReadSetting("EnableBundles"));
        }
    }
}