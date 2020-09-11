using HomePageVST.Controllers.Core;
using System.Web.Mvc;

namespace HomePageVST.Controllers
{
    public class FacilitiesController : ControllerCore
    {
        // GET: Facilities
        public ActionResult Index()
        {
            return View();
        }
    }
}