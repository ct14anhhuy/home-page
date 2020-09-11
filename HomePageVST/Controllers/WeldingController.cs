using HomePageVST.Controllers.Core;
using Services.Interfaces;
using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Controllers
{
    public class WeldingController : ControllerCore
    {
        private IDocumentService _documentService;

        public WeldingController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        // GET: Welding
        public ActionResult Index()
        {
            var listDocumentDTO = _documentService.GetListActivedDocumentByCategoryId(CommonConstants.WELDING_CATEGORY_ID);
            return View(listDocumentDTO);
        }
    }
}