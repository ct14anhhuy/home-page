using HomePageVST.Controllers.Core;
using System.Web.Mvc;

namespace HomePageVST.Controllers
{
    public class VisionController : ControllerCore
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}