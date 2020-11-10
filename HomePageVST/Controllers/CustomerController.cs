using DTO;
using HomePageVST.Controllers.Core;
using Services.Interfaces;
using System.Web.Mvc;

namespace HomePageVST.Controllers
{
    public class CustomerController : ControllerCore
    {
        private ICustomerService _customerService;
        private const string ZSCALER_ADDRESS = "165.225.112";

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public JsonResult Register(CustomerDTO customer)
        {
            if (ModelState.IsValid)
            {
                bool checkExists = _customerService.GetCustomerByEmail(customer.Email);
                if (checkExists)
                {
                    return Json(new { createdSuccess = false, isExists = true }, JsonRequestBehavior.AllowGet);
                }
                _customerService.CreateCustomer(customer);
                return Json(new { createdSuccess = true, isExists = false }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { createdSuccess = false, isExists = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult CheckLoggedIn()
        {
            bool isCompanyAddress = Request.UserHostAddress.Contains(ZSCALER_ADDRESS) ? true : false;
            bool isLoggedIn = Session["CustomerEmail"] != null;
            return Json(new { isLoggedIn, isCompanyAddress }, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public JsonResult ChangePassword(string password, string newPassword)
        {
            if (Session["CustomerEmail"] == null)
            {
                return Json(new { isChangedSuccess = false }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                string email = Session["CustomerEmail"].ToString();
                bool isChangedSuccess = _customerService.ChangePassword(email, password, newPassword);
                if (isChangedSuccess)
                {
                    Session["CustomerEmail"] = null;
                    Session.Clear();
                }
                return Json(new { isChangedSuccess }, JsonRequestBehavior.AllowGet);
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