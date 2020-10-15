using HomePageVST.Filters;
using HomePageVST.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HomePageVST.Controllers
{
    public class SitemapController : Controller
    {
        private IHeaderDetailService _headerDetailService;
        private const string WEBSITE_URL = "http://www.poscovst.com.vn/";

        public SitemapController(IHeaderDetailService headerDetailService)
        {
            _headerDetailService = headerDetailService;
        }

        [OutputCache(Duration = 1800, VaryByParam = "none")]
        public SitemapActionResult Index()
        {
            var sitemapItems = new List<SitemapViewModels>();
            var urls = _headerDetailService.GetUrls();

            sitemapItems.Add(new SitemapViewModels
            {
                URL = "",
                Priority = "1",
                DateAdded = new DateTime(2020, 10, 5)
            });

            sitemapItems.Add(new SitemapViewModels
            {
                URL = "home.html",
                Priority = "1",
                DateAdded = new DateTime(2020, 10, 5)
            });

            sitemapItems.Add(new SitemapViewModels
            {
                URL = "site-map.html",
                Priority = "1",
                DateAdded = new DateTime(2020, 10, 5)
            });

            foreach (var url in urls)
            {
                sitemapItems.Add(new SitemapViewModels
                {
                    URL = $"{url.Alias}.html",
                    Priority = ".8",
                    DateAdded = new DateTime(2020, 10, 5)
                });
            }
            return new SitemapActionResult(sitemapItems, WEBSITE_URL);
        }
    }
}