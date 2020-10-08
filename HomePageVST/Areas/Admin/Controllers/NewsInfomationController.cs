using DTO;
using HomePageVST.Controllers.Core;
using HomePageVST.Filters.AntiModelInjection;
using Services.Interfaces;
using System;
using System.Net;
using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Areas.Admin.Controllers
{
    [Authorize]
    public class NewsInfomationController : ControllerCore
    {
        private IImageService _imageService;
        public NewsInfomationController(IImageService imageService)
        {
            _imageService = imageService;
            ViewBag.Active = "news";
        }

        public ActionResult Index()
        {
            var images = _imageService.GetImagesByHeaderDetailId(CommonConstants.NEWS_INFOMATION_ID);
            return View(images);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImageDTO imageDTO)
        {
            imageDTO.DatePosted = DateTime.Today;
            imageDTO.IsActive = true;
            imageDTO.HeaderDetailId = CommonConstants.NEWS_INFOMATION_ID;
            ModelState["DatePosted"].Errors.Clear();

            if (ModelState.IsValid)
            {
                _imageService.Add(imageDTO);
                return RedirectToAction("Index");
            }
            else
            {
                return View(imageDTO);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var imageDTO = _imageService.GetImageByHeaderDetailId((int)id);
            if (imageDTO == null)
            {
                return HttpNotFound();
            }
            return View(imageDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("Id")]
        [ValidateAntiModelInjection("HeaderDetailId")]
        [ValidateAntiModelInjection("FilePath")]
        [ValidateAntiModelInjection("MinimalFilePath")]
        [ValidateAntiModelInjection("DatePosted")]
        public ActionResult Edit(ImageDTO imageDTO)
        {
            if (ModelState.IsValid)
            {
                _imageService.Edit(imageDTO);
                return RedirectToAction("Index");
            }
            else
            {
                return View(imageDTO);
            }
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var imageDTO = _imageService.GetImageByHeaderDetailId((int)id);
            if (imageDTO == null)
            {
                return HttpNotFound();
            }
            return View(imageDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ImageDTO imageDTO)
        {
            _imageService.Delete(imageDTO.Id);
            return RedirectToAction("Index");
        }
    }
}