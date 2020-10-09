using HomePageVST.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Xml;

namespace HomePageVST.Filters
{
    public class SitemapActionResult : ActionResult
    {
        private List<SitemapViewModels> _sitemap;
        private string _Website;

        public SitemapActionResult(List<SitemapViewModels> sitemap, string Website)
        {
            _sitemap = sitemap;
            _Website = Website;
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
                    writer.WriteElementString("loc", string.Format(this._Website + "{0}", siteMapItem.URL));
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