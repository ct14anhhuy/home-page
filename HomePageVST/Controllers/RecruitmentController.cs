using HomePageVST.Controllers.Core;
using Services.Interfaces;
using System.Web.Mvc;

namespace HomePageVST.Controllers
{
    public class RecruitmentController : ControllerCore
    {
        private IRecruitmentService _recruitmentService;

        public RecruitmentController(IRecruitmentService recruitmentService)
        {
            _recruitmentService = recruitmentService;
        }

        public ActionResult Index()
        {
            var recruitments = _recruitmentService.GetActivedRecruitment();
            return View(recruitments);
        }
    }
}