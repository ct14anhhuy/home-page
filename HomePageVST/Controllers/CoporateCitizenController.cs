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
            var images = _imageService.GetImagesByHeaderDetailId(CommonConstants.COPORATE_CITIZEN);
            return View(images);
        }
    }
}