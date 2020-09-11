using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Controllers.Core
{
    public class ControllerCore : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            string errorMsg = filterContext.Exception.Message;
            filterContext.ExceptionHandled = true;
            LogHelper.Error(errorMsg);
            ViewData["ErrorMessage"] = errorMsg;
            filterContext.Result = new ViewResult
            {
                ViewData = this.ViewData,
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }
    }
}