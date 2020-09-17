using HomePageVST.Models;
using Services.Interfaces;
using System;
using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Areas.Admin.Controllers
{
    [Authorize]
    public class NewsInfomationController : Controller
    {
        private IImageService _imageService;
        public NewsInfomationController(IImageService imageService)
        {
            _imageService = imageService;
            ViewBag.Active = "news";
        }

        public ActionResult Index()
        {
            var images = _imageService.GetAll();
            return View(images);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImageViewModel imageViewModel)
        {
            imageViewModel.DatePosted = DateTime.Today;
            imageViewModel.IsActive = true;
            imageViewModel.HeaderDetailId = CommonConstants.NEWS_INFOMATION_ID;
            ModelState["DatePosted"].Errors.Clear();
            ModelState["IsActive"].Errors.Clear();

            if (ModelState.IsValid)
            {
                _imageService.Add(imageViewModel);
                return RedirectToAction("Index");
            }
            else
            {
                return View(imageViewModel);
            }
        }
    }
}