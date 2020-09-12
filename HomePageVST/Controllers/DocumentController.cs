using HomePageVST.Controllers.Core;
using Services.Interfaces;
using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Controllers
{
    public class DocumentController : ControllerCore
    {
        private IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        // GET: Document
        public ActionResult GetReport(string fileName)
        {
            ViewBag.PdfFileName = ConfigHelper.ReadSetting("PdfShortPath") + fileName;
            return View();
        }
    }
}