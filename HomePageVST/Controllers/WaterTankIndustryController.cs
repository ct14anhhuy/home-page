using HomePageVST.Controllers.Core;
using Services;
using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Controllers
{
    public class WaterTankIndustryController : ControllerCore
    {
        private DocumentService _documentService;

        public WaterTankIndustryController()
        {
            _documentService = new DocumentService();
        }

        // GET: WaterTankIndustry
        public ActionResult Index()
        {
            var listDocumentDTO = _documentService.GetListActivedDocumentByCategoryId(CommonConstants.WTI_CATEGORY_ID);
            return View(listDocumentDTO);
        }
    }
}