using DTO;
using HomePageVST.Controllers.Core;
using Services.Interfaces;
using System.Web.Mvc;

namespace HomePageVST.Controllers
{
    public class CustomerController : ControllerCore
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public JsonResult Register(CustomerDTO customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.CreateCustomer(customer);
                return Json(new { createdSuccess = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { createdSuccess = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult CheckLoggedIn()
        {
            bool logged = Session["CustomerEmail"] != null;
            return Json(new { logged = logged }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Login(string email, string password)
        {
            var result = _customerService.CheckLogin(email, password);
            if (result)
            {
                Session["CustomerEmail"] = email;
                return Json(new { loginSuccess = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { loginSuccess = false }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Logout()
        {
            Session["CustomerEmail"] = null;
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}