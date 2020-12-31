using HomePageVST.Controllers.Core;
using Services.Interfaces;
using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Controllers
{
    public class FormingController : ControllerCore
    {
        private readonly IDocumentService _documentService;

        public FormingController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public ActionResult Index()
        {
            var listDocumentDTO = _documentService.GetListActivedDocumentByCategoryId(CommonConstants.FORMING_CATEGORY_ID);
            return View(listDocumentDTO);
        }
    }
}