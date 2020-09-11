using DTO;
using HomePageVST.Controllers.Core;
using HomePageVST.Filters.AntiModelInjection;
using Services.Interfaces;
using System;
using System.Net;
using System.Web.Mvc;

namespace HomePageVST.Areas.Admin.Controllers
{
    [Authorize]
    public class RecruitmentController : ControllerCore
    {
        private IRecruitmentService _recruitmentService;

        public RecruitmentController(IRecruitmentService recruitmentService)
        {
            _recruitmentService = recruitmentService;
            ViewBag.Active = "recruitment";
        }

        public ActionResult Index()
        {
            var listRecruitment = _recruitmentService.GetAll();
            return View(listRecruitment);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(RecruitmentDTO recruitment)
        {
            recruitment.IsActive = true;
            recruitment.DatePosted = DateTime.Today;

            if (ModelState.IsValid)
            {
                try
                {
                    _recruitmentService.Add(recruitment);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(recruitment);
                }
            }
            else
            {
                return View(recruitment);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var recruitment = _recruitmentService.GetDetailByID((int)id);
            if (recruitment == null)
            {
                return HttpNotFound();
            }
            return View(recruitment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("Id")]
        [ValidateInput(false)]
        public ActionResult Edit(RecruitmentDTO recruitment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _recruitmentService.Edit(recruitment);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(recruitment);
                }
            }
            else
            {
                return View(recruitment);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var recruitment = _recruitmentService.GetDetailByID((int)id);
            if (recruitment == null)
            {
                return HttpNotFound();
            }
            return View(recruitment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RecruitmentDTO recruitment)
        {
            _recruitmentService.Delete(recruitment.Id);
            return RedirectToAction("Index");
        }
    }
}