using Services.Interfaces;
using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Controllers
{
    public class CoporateCitizenController : Controller
    {
        private IImageService _imageService;

        public CoporateCitizenController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public ActionResult Index()
        {
            var images = _imageService.GetActiveImagesByHeaderDetailId(CommonConstants.COPORATE_CITIZEN_ID);
            return View(images);
        }
    }
}