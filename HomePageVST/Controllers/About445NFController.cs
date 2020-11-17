using HomePageVST.Controllers.Core;
using Services.Interfaces;
using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Controllers
{
    public class About445NFController : ControllerCore
    {
        private IDocumentService _documentService;

        public About445NFController(IDocumentService documentService)
        {
            _documentService = documentService;
        }
        
        public ActionResult Index()
        {
            var listDocumentDTO = _documentService.GetListActivedDocumentByCategoryId(CommonConstants._445NF_CATEGORY_ID);
            return View(listDocumentDTO);
        }
    }
}