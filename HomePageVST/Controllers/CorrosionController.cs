using HomePageVST.Controllers.Core;
using Services.Interfaces;
using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Controllers
{
    public class CorrosionController : ControllerCore
    {
        private readonly IDocumentService _documentService;

        public CorrosionController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public ActionResult Index()
        {
            var listDocumentDTO = _documentService.GetListActivedDocumentByCategoryId(CommonConstants.CORROSION_CATEGORY_ID);
            return View(listDocumentDTO);
        }
    }
}