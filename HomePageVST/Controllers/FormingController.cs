using HomePageVST.Controllers.Core;
using Services;
using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Controllers
{
    public class FormingController : ControllerCore
    {
        private DocumentService _documentService;

        public FormingController()
        {
            _documentService = new DocumentService();
        }

        // GET: Forming
        public ActionResult Index()
        {
            var listDocumentDTO = _documentService.GetListActivedDocumentByCategoryId(CommonConstants.FORMING_CATEGORY_ID);
            return View(listDocumentDTO);
        }
    }
}