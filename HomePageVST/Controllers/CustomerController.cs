using DTO;
using HomePageVST.Controllers.Core;
using Services.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;
using Utilities;

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
        public async Task<JsonResult> Register(CustomerDTO customer)
        {
            if (ModelState.IsValid)
            {
                string verifyEmail = ConfigHelper.ReadSetting("VerifyEmail");
                bool checkExists = _customerService.GetCustomerByEmail(customer.Email);
                if (checkExists)
                {
                    return Json(new { isCreateSuccess = false, isExists = true }, JsonRequestBehavior.AllowGet);
                }
                await _customerService.CreateCustomer(customer);
                return Json(new { isCreateSuccess = true, isExists = false }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isCreateSuccess = false, isExists = false }, JsonRequestBehavior.AllowGet);
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
                return Json(new { isLoginSuccess = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isLoginSuccess = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ChangePassword(string password, string newPassword)
        {
            if (Session["CustomerEmail"] == null)
            {
                return Json(new { isChangeSuccess = false }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                string email = Session["CustomerEmail"].ToString();
                bool isChangeSuccess = _customerService.ChangePassword(email, password, newPassword);
                if (isChangeSuccess)
                {
                    Session["CustomerEmail"] = null;
                    Session.Clear();
                }
                return Json(new { isChangeSuccess }, JsonRequestBehavior.AllowGet);
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