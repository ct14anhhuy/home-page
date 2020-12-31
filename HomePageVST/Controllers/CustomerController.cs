using DTO;
using HomePageVST.Controllers.Core;
using Newtonsoft.Json;
using Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Utilities;

namespace HomePageVST.Controllers
{
    public class CustomerController : ControllerCore
    {
        private readonly ICustomerService _customerService;
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
                string verifyEmail = ConfigHelper.Read("VerifyEmail");
                bool checkExists = _customerService.GetCustomerByEmail(customer.Email);
                if (checkExists)
                {
                    return Json(new { isCreateSuccess = false, isExists = true }, JsonRequestBehavior.AllowGet);
                }
                var isCreateSuccess = await _customerService.CreateCustomer(customer);
                return Json(new { isCreateSuccess, isExists = false }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var modelErrors = JsonConvert.SerializeObject(ModelState.Values.Where(x => x.Errors.Count > 0));
                return Json(new { isCreateSuccess = false, modelErrors }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult CheckLoggedIn()
        {
            bool isCompanyAddress = Request.UserHostAddress.Contains(ZSCALER_ADDRESS);
            bool isLoggedIn = Session["CustomerEmail"] != null;
            return Json(new { isLoggedIn, isCompanyAddress }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Login(CustomerDTO customer)
        {
            if (ModelState.IsValidField("Email") && ModelState.IsValidField("Password"))
            {
                var result = _customerService.CheckLogin(customer.Email, customer.Password);
                if (result)
                {
                    Session["CustomerEmail"] = customer.Email;
                }
                return Json(new { isLoginSuccess = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var modelErrors = JsonConvert.SerializeObject(ModelState.Values.Where(x => x.Errors.Count > 0));
                return Json(new { isLoginSuccess = false, modelErrors }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ChangePassword(CustomerDTO customer)
        {
            if (string.IsNullOrEmpty(customer.NewPassword))
            {
                ModelState.AddModelError("NewPassword", "Enter your new password");
            }
            if (ModelState.IsValidField("Password") && ModelState.IsValidField("NewPassword") && ModelState.IsValidField("ConfirmNewPassword"))
            {
                string email = Session["CustomerEmail"].ToString();
                bool isChangeSuccess = _customerService.ChangePassword(email, customer.Password, customer.NewPassword);
                if (isChangeSuccess)
                {
                    Session["CustomerEmail"] = null;
                    Session.Clear();
                }
                return Json(new { isChangeSuccess }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var modelErrors = JsonConvert.SerializeObject(ModelState.Values.Where(x => x.Errors.Count > 0));
                return Json(new { isChangeSuccess = false, modelErrors }, JsonRequestBehavior.AllowGet);
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