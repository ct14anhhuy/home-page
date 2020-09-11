using HomePageVST.Controllers.Core;
using Services;
using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Controllers
{
    public class CorrosionController : ControllerCore
    {
        private DocumentService _documentService;

        public CorrosionController()
        {
            _documentService = new DocumentService();
        }

        // GET: Corrosion
        public ActionResult Index()
        {
            var listDocumentDTO = _documentService.GetListActivedDocumentByCategoryId(CommonConstants.CORROSION_CATEGORY_ID);
            return View(listDocumentDTO);
        }
    }
}