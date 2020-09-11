using HomePageVST.Controllers.Core;
using System.Web.Mvc;

namespace HomePageVST.Controllers
{
    public class VisionController : ControllerCore
    {
        // GET: Vision
        public ActionResult Index()
        {
            return View();
        }
    }
}