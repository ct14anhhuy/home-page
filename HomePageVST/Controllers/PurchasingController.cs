using HomePageVST.Controllers.Core;
using System.Web.Mvc;

namespace HomePageVST.Controllers
{
    public class PurchasingController : ControllerCore
    {
        // GET: Purchasing
        public ActionResult Index()
        {
            return View();
        }
    }
}