using HomePageVST.Controllers.Core;
using System.Web.Mvc;

namespace HomePageVST.Controllers
{
    public class NewsInformationController : ControllerCore
    {
        // GET: NewsInformation
        public ActionResult Index()
        {
            return View();
        }
    }
}