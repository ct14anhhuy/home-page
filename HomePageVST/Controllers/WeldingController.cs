using HomePageVST.Controllers.Core;
using Services;
using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Controllers
{
    public class WeldingController : ControllerCore
    {
        private DocumentService _documentService;

        public WeldingController()
        {
            _documentService = new DocumentService();
        }

        // GET: Welding
        public ActionResult Index()
        {
            var listDocumentDTO = _documentService.GetListActivedDocumentByCategoryId(CommonConstants.WELDING_CATEGORY_ID);
            return View(listDocumentDTO);
        }
    }
}