using HomePageVST.Controllers.Core;
using Services.Interfaces;
using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Controllers
{
    public class NewsInformationController : ControllerCore
    {
        private IImageService _imageService;
        public NewsInformationController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public ActionResult Index()
        {
            var images = _imageService.GetActiveImagesByHeaderDetailId(CommonConstants.NEWS_INFOMATION_ID);
            return View(images);
        }
    }
}