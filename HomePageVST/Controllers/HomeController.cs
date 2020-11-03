using HomePageVST.Controllers.Core;
using HomePageVST.Filters;
using Services.Interfaces;
using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Controllers
{
    public class HomeController : ControllerCore
    {
        private IHeaderDetailService _headerDetailService;
        private IImageService _imageService;

        public HomeController(IHeaderDetailService headerDetailService, IImageService imageService)
        {
            _headerDetailService = headerDetailService;
            _imageService = imageService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowSiteMap()
        {
            return View();
        }

        public ActionResult ApplicationOfSTS()
        {
            return View();
        }

        [ChildActionOnly]
        [PartialCache("Cache-1H-CS")]
        public ActionResult CoporateCitizenImageSlide()
        {
            var images = _imageService.GetActiveImagesByHeaderDetailId(CommonConstants.COPORATE_CITIZEN_ID);
            return PartialView(images);
        }

        [ChildActionOnly]
        //[PartialCache("Cache-1H-CS")]
        public ActionResult Header()
        {
            var listHeaderDetailDTO = _headerDetailService.GetMenus();
            return PartialView(listHeaderDetailDTO);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }
    }
}