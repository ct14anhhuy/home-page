using HomePageVST.Controllers.Core;
using Services;
using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Controllers
{
    public class DocumentController : ControllerCore
    {
        private DocumentService _documentService;

        public DocumentController()
        {
            _documentService = new DocumentService();
        }

        // GET: Document
        public ActionResult GetReport(string fileName)
        {
            ViewBag.PdfFileName = ConfigHelper.ReadSetting("PdfShortPath") + fileName;
            return View();
        }
    }
}