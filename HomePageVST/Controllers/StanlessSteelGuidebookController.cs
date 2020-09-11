using HomePageVST.Controllers.Core;
using Services;
using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Controllers
{
    public class StanlessSteelGuidebookController : ControllerCore
    {
        private DocumentService _documentService;

        public StanlessSteelGuidebookController()
        {
            _documentService = new DocumentService();
        }

        // GET: StanlessSteelGuidebook
        public ActionResult Index()
        {
            var listDocumentDTO = _documentService.GetListActivedDocumentByCategoryId(CommonConstants.SSG_CATEGORY_ID);
            return View(listDocumentDTO);
        }
    }
}