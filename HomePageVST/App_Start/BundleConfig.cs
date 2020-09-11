﻿using System.Web.Optimization;
using Utilities;

namespace HomePageVST
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/plugins").Include(
                "~/Scripts/jquery.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/owl.carousel.min.js",
                "~/Scripts/jquery.stellar.min.js",
                "~/Scripts/jquery.sticky.js",
                "~/Scripts/jquery.stellar.min.js",
                "~/Scripts/wow.min.js",
                "~/Scripts/smoothscroll.js",
                "~/Scripts/lightbox.min.js"
               ));

            bundles.Add(new ScriptBundle("~/js/customs").Include(
                "~/Scripts/scripts.js",
                "~/Scripts/left-menu.js",
                "~/Scripts/custom.js",
                "~/Scripts/dialog.js"
               ));

            bundles.Add(new StyleBundle("~/css/base")
             .Include("~/css/bootstrap.min.css", new CssRewriteUrlTransform())
             .Include("~/css/font-awesome.min.css", new CssRewriteUrlTransform())
             .Include("~/css/animate.css", new CssRewriteUrlTransform())
             .Include("~/css/owl.carousel.css", new CssRewriteUrlTransform())
             .Include("~/css/owl.theme.default.min.css", new CssRewriteUrlTransform())
             .Include("~/css/style.css", new CssRewriteUrlTransform())
             .Include("~/css/colors1.css", new CssRewriteUrlTransform())
             .Include("~/css/tooplate-style.css", new CssRewriteUrlTransform())
             .Include("~/css/lightbox.css", new CssRewriteUrlTransform())
             );

            bundles.Add(new StyleBundle("~/css/customs")
               .Include("~/css/customs.css", new CssRewriteUrlTransform())
               .Include("~/css/left-menu.css", new CssRewriteUrlTransform())
               .Include("~/css/dialog.css", new CssRewriteUrlTransform())
               );

            BundleTable.EnableOptimizations = bool.Parse(ConfigHelper.ReadSetting("EnableBundles"));
        }
    }
}