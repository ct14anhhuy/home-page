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

        // GET: NewsInformation
        public ActionResult Index()
        {
            var images = _imageService.GetImagesByHeaderDetailId(CommonConstants.NEWS_INFOMATION);
            return View(images);
        }
    }
}