using HomePageVST.Controllers.Core;
using Services.Interfaces;
using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Controllers
{
    public class StanlessSteelGuidebookController : ControllerCore
    {
        private IDocumentService _documentService;

        public StanlessSteelGuidebookController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public ActionResult Index()
        {
            var listDocumentDTO = _documentService.GetListActivedDocumentByCategoryId(CommonConstants.SSG_CATEGORY_ID);
            return View(listDocumentDTO);
        }
    }
}