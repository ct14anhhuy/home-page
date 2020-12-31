using HomePageVST.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Xml;

namespace HomePageVST.Filters
{
    public class SitemapActionResult : ActionResult
    {
        private readonly List<SitemapViewModels> _sitemap;
        private readonly string _website;

        public SitemapActionResult(List<SitemapViewModels> sitemap, string website)
        {
            _sitemap = sitemap;
            _website = website;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "text/xml";
            using (XmlWriter writer = XmlWriter.Create(context.HttpContext.Response.Output))
            {
                writer.WriteStartElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");
                foreach (var siteMapItem in _sitemap)
                {
                    writer.WriteStartElement("url");
                    writer.WriteElementString("loc", string.Format(_website + "{0}", siteMapItem.URL));
                    if (siteMapItem.DateAdded != null)
                    {
                        writer.WriteElementString("lastmod", string.Format("{0:yyyy-MM-dd}", siteMapItem.DateAdded));
                    }
                    writer.WriteElementString("changefreq", "daily");
                    writer.WriteElementString("priority", siteMapItem.Priority);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.Flush();
                writer.Close();
            }
        }
    }
}