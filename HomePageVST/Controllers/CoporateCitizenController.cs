using HomePageVST.Controllers.Core;
using HomePageVST.Models;
using Services.Interfaces;
using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Controllers
{
    public class CoporateCitizenController : ControllerCore
    {
        private IImageService _imageService;
        private ICoporateCitizenCategoryService _coporateCitizenCategoryService;
        private ICoporateCitizenContentService _coporateCitizenContentService;

        public CoporateCitizenController(IImageService imageService,
            ICoporateCitizenCategoryService coporateCitizenCategoryService,
            ICoporateCitizenContentService coporateCitizenContentService)
        {
            _imageService = imageService;
            _coporateCitizenCategoryService = coporateCitizenCategoryService;
            _coporateCitizenContentService = coporateCitizenContentService;
        }

        public ActionResult Index()
        {
            var images = _imageService.GetActiveImagesByHeaderDetailId(CommonConstants.COPORATE_CITIZEN_ID);
            var categories = _coporateCitizenCategoryService.GetAll();
            var coporateCitizenVM = new CoporateCitizenViewModels() { Images = images, CoporateCitizenCategories = categories };
            return View(coporateCitizenVM);
        }
        
        public ActionResult Newsroom(int categoryId)
        {
            var content = _coporateCitizenContentService.GetContentByCategoryId(categoryId);
            return View(content);
        }
    }
}