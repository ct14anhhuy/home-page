using HomePageVST.Controllers.Core;
using Services;
using System.Web.Mvc;

namespace HomePageVST.Controllers
{
    public class RecruitmentController : ControllerCore
    {
        private RecruitmentService _recruitmentService;

        public RecruitmentController()
        {
            _recruitmentService = new RecruitmentService();
        }

        // GET: Recruitment
        public ActionResult Index()
        {
            var recruitments = _recruitmentService.GetActivedRecruitment();
            return View(recruitments);
        }
    }
}