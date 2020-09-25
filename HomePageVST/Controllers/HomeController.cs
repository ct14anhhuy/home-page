using HomePageVST.Controllers.Core;
using HomePageVST.Models;
using Services.Interfaces;
using System.Linq;
using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Controllers
{
    public class HomeController : ControllerCore
    {
        private IHeaderCategoryService _headerCategoryService;
        private IHeaderDetailService _headerDetailService;
        private IImageService _imageService;

        public HomeController(IHeaderCategoryService headerCategoryService, IHeaderDetailService headerDetailService, IImageService imageService)
        {
            _headerCategoryService = headerCategoryService;
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
        [OutputCache(Duration = 3600, VaryByParam = "none")]
        public ActionResult CoporateCitizenImageSlide()
        {
            var images = _imageService.GetActiveImagesByHeaderDetailId(CommonConstants.COPORATE_CITIZEN_ID);
            return PartialView(images);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600, VaryByParam = "none")]
        public ActionResult Header()
        {
            var listHheaderCategoryDTO = _headerCategoryService.GetAll();
            var listHeaderDetailDTO = _headerDetailService.GetAll();
            var listHeaderCategoryViewModel = from c in listHheaderCategoryDTO
                                              join d in listHeaderDetailDTO on c.Id equals d.HeaderCategoryId
                                              select new HeaderCategoryViewModel
                                              {
                                                  HeaderCategoryId = c.Id,
                                                  HeaderCategoryName = c.Name,
                                                  HeaderDetailId = d.Id,
                                                  HeaderDetailName = d.Name,
                                                  HeaderDetailAlias = d.Alias,
                                                  ParentId = d.ParentId
                                              };
            return PartialView(listHeaderCategoryViewModel);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }
    }
}