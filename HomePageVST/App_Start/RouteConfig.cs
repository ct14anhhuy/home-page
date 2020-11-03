using System.Web.Mvc;
using System.Web.Routing;

namespace HomePageVST
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Home",
              url: "home.html",
              defaults: new { controller = "Home", action = "Index" },
              namespaces: new string[] { "HomePageVST.Controllers" }
           );

            routes.MapRoute(
              name: "SiteMap",
              url: "site-map.html",
              defaults: new { controller = "Home", action = "ShowSiteMap" },
              namespaces: new string[] { "HomePageVST.Controllers" }
           );

            routes.MapRoute(
              name: "ApplicationOfSTS",
              url: "application-of-sts.html",
              defaults: new { controller = "Home", action = "ApplicationOfSTS" },
              namespaces: new string[] { "HomePageVST.Controllers" }
           );

            routes.MapRoute(
              name: "Document",
              url: "docs/vw/{docId}",
              defaults: new { controller = "Document", action = "GetReport", docId = UrlParameter.Optional },
              namespaces: new string[] { "HomePageVST.Controllers" }
           );

            Introduction(routes);
            Product(routes);
            OpenBusiness(routes);
            PR(routes);
            Contact(routes);
            About(routes);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "HomePageVST.Controllers" }
            );
        }

        private static void About(RouteCollection routes)
        {
            routes.MapRoute(
              name: "StainlessSteelGuidebook",
              url: "stainless-steel-guidebook.html",
              defaults: new { controller = "StanlessSteelGuidebook", action = "Index" },
              namespaces: new string[] { "HomePageVST.Controllers" }
           );

            routes.MapRoute(
              name: "Corrosion",
              url: "corrosion.html",
              defaults: new { controller = "Corrosion", action = "Index" },
              namespaces: new string[] { "HomePageVST.Controllers" }
           );

            routes.MapRoute(
              name: "Welding",
              url: "welding.html",
              defaults: new { controller = "Welding", action = "Index" },
              namespaces: new string[] { "HomePageVST.Controllers" }
           );

            routes.MapRoute(
              name: "Forming",
              url: "forming.html",
              defaults: new { controller = "Forming", action = "Index" },
              namespaces: new string[] { "HomePageVST.Controllers" }
           );

            routes.MapRoute(
              name: "WaterTankIndustry",
              url: "water-tank-industry.html",
              defaults: new { controller = "WaterTankIndustry", action = "Index" },
              namespaces: new string[] { "HomePageVST.Controllers" }
           );

            routes.MapRoute(
              name: "About445NF",
              url: "about-445nf.html",
              defaults: new { controller = "About445NF", action = "Index" },
              namespaces: new string[] { "HomePageVST.Controllers" }
           );
        }

        private static void Introduction(RouteCollection routes)
        {
            routes.MapRoute(
              name: "Introduction",
              url: "introduction.html",
              defaults: new { controller = "Introduction", action = "Index" },
              namespaces: new string[] { "HomePageVST.Controllers" }
           );

            routes.MapRoute(
               name: "History",
               url: "history.html",
               defaults: new { controller = "History", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "Organization",
               url: "organization.html",
               defaults: new { controller = "Organization", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "Vision",
               url: "vision.html",
               defaults: new { controller = "Vision", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );
        }

        private static void Product(RouteCollection routes)
        {
            routes.MapRoute(
               name: "C301301L",
               url: "301301l.html",
               defaults: new { controller = "C301301L", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "C301CU",
               url: "301cu.html",
               defaults: new { controller = "C301CU", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "C304304L",
               url: "304304l.html",
               defaults: new { controller = "C304304L", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "C304CU",
               url: "304cu.html",
               defaults: new { controller = "C304CU", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "C310S",
               url: "310s.html",
               defaults: new { controller = "C310S", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "C316316L",
               url: "316316l.html",
               defaults: new { controller = "C316316L", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "C321",
               url: "321.html",
               defaults: new { controller = "C321", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "C329J3L",
               url: "329j3l.html",
               defaults: new { controller = "C329J3L", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "C409L",
               url: "409l.html",
               defaults: new { controller = "C409L", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "C410S",
               url: "410s.html",
               defaults: new { controller = "C410S", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "C420J1420J2",
               url: "420j1420j2.html",
               defaults: new { controller = "C420J1420J2", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "C420N1",
               url: "420n1.html",
               defaults: new { controller = "C420N1", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "C430",
               url: "430.html",
               defaults: new { controller = "C430", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "C430J1L",
               url: "430j1l.html",
               defaults: new { controller = "C430J1L", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "C430RE",
               url: "430re.html",
               defaults: new { controller = "C430RE", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "C436L",
               url: "436l.html",
               defaults: new { controller = "C436L", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "C439430LX",
               url: "439430lx.html",
               defaults: new { controller = "C439430LX", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "C441",
               url: "441.html",
               defaults: new { controller = "C441", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "C444",
               url: "444.html",
               defaults: new { controller = "C444", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "C445NF",
               url: "445nf.html",
               defaults: new { controller = "C445NF", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "Precision",
               url: "precision.html",
               defaults: new { controller = "Precision", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "SurfaceProcessing",
               url: "surface-processing.html",
               defaults: new { controller = "SurfaceProcessing", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "No4HLSurface",
               url: "no4-hl-surface.html",
               defaults: new { controller = "No4HLSurface", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "ProductionProcess2B",
               url: "production-process-2b.html",
               defaults: new { controller = "ProductionProcess2B", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "ProductionProcessBA",
               url: "production-process-ba.html",
               defaults: new { controller = "ProductionProcessBA", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );
        }

        private static void OpenBusiness(RouteCollection routes)
        {
            routes.MapRoute(
              name: "Recruitment",
              url: "recruitment.html",
              defaults: new { controller = "Recruitment", action = "Index" },
              namespaces: new string[] { "HomePageVST.Controllers" }
           );

            routes.MapRoute(
              name: "ScrapBidding",
              url: "scrap-bidding.html",
              defaults: new { controller = "ScrapBidding", action = "Index" },
              namespaces: new string[] { "HomePageVST.Controllers" }
          );

            routes.MapRoute(
              name: "Purchasing",
              url: "purchasing.html",
              defaults: new { controller = "Purchasing", action = "Index" },
              namespaces: new string[] { "HomePageVST.Controllers" }
          );

            routes.MapRoute(
              name: "Ethics",
              url: "ethics.html",
              defaults: new { controller = "Ethics", action = "Index" },
              namespaces: new string[] { "HomePageVST.Controllers" }
          );
        }

        private static void PR(RouteCollection routes)
        {
            routes.MapRoute(
              name: "CoporateCitizenNewsroom",
              url: "coporate-citizen-newsroom-p{categoryId}.html",
              defaults: new { controller = "CoporateCitizen", action = "Newsroom", categoryId = UrlParameter.Optional },
              namespaces: new string[] { "HomePageVST.Controllers" }
           );

            routes.MapRoute(
               name: "CoporateCitizen",
               url: "coporate-citizen.html",
               defaults: new { controller = "CoporateCitizen", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "NewsInformation",
               url: "news-information.html",
               defaults: new { controller = "NewsInformation", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "Facilities",
               url: "facilities.html",
               defaults: new { controller = "Facilities", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );
        }

        private static void Contact(RouteCollection routes)
        {
            routes.MapRoute(
               name: "ContactVST",
               url: "contact-vst.html",
               defaults: new { controller = "ContactVST", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );

            routes.MapRoute(
               name: "posco-family",
               url: "posco-family.html",
               defaults: new { controller = "PoscoFamily", action = "Index" },
               namespaces: new string[] { "HomePageVST.Controllers" }
            );
        }
    }
}