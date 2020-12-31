using HomePageVST.Controllers.Core;
using Services.Interfaces;
using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Controllers
{
    public class DocumentController : ControllerCore
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public ActionResult GetReport(int docId)
        {
            string fileName = _documentService.GetDocumentById(docId).FileName;
            ViewBag.PdfFileName = ConfigHelper.Read("Pdf.Path") + fileName;
            return View();
        }
    }
}