using DTO;
using HomePageVST.Controllers.Core;
using HomePageVST.Filters.AntiModelInjection;
using HomePageVST.Models;
using Services.Interfaces;
using System;
using System.Net;
using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Areas.Admin.Controllers
{
    [Authorize]
    public class CoporateCitizenController : ControllerCore
    {
        private IImageService _imageService;

        public CoporateCitizenController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public ActionResult Index()
        {
            var images = _imageService.GetImagesByHeaderDetailId(CommonConstants.COPORATE_CITIZEN_ID);
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
            imageViewModel.HeaderDetailId = CommonConstants.COPORATE_CITIZEN_ID;
            ModelState["DatePosted"].Errors.Clear();

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