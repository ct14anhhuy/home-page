using HomePageVST.Controllers.Core;
using System.Web.Mvc;

namespace HomePageVST.Controllers
{
    public class OrganizationController : ControllerCore
    {
        // GET: Organization
        public ActionResult Index()
        {
            return View();
        }
    }
}