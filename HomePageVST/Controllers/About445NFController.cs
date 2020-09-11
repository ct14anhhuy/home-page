using HomePageVST.Controllers.Core;
using Services;
using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Controllers
{
    public class About445NFController : ControllerCore
    {
        private DocumentService _documentService;

        public About445NFController()
        {
            _documentService = new DocumentService();
        }

        // GET: About445NF
        public ActionResult Index()
        {
            var listDocumentDTO = _documentService.GetListActivedDocumentByCategoryId(CommonConstants._445NF_CATEGORY_ID);
            return View(listDocumentDTO);
        }
    }
}