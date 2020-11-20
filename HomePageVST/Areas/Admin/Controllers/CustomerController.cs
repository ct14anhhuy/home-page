using DTO;
using HomePageVST.Controllers.Core;
using HomePageVST.Extensions.AntiModelInjection;
using Services.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HomePageVST.Areas.Admin.Controllers
{
    [Authorize]
    public class CustomerController : ControllerCore
    {
        private ICustomerService _customerService;
        private const string POSCO_MAIL_ADDRESS = "116.127.24.126";

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
            ViewBag.Active = "customer";
        }

        public ActionResult Index()
        {
            var customers = _customerService.GetAll();
            return View(customers);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = _customerService.GetById((int)id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("Id")]
        public ActionResult Edit(CustomerDTO customer)
        {
            ModelState["Password"].Errors.Clear();
            if (ModelState.IsValid)
            {
                try
                {
                    _customerService.Edit(customer);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(customer);
                }
            }
            else
            {
                return View(customer);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = _customerService.GetById((int)id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CustomerDTO customer)
        {
            _customerService.Delete(customer.Id);
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public async Task<ActionResult> VerifyCustomer(int id)
        {
            ViewBag.EmailResponseMsg = "";
            if (Request.UserHostAddress != POSCO_MAIL_ADDRESS)
            {
                var result = await _customerService.VerifyCustomer(id);
                ViewBag.EmailResponseMsg = result ? "Verify successful, an email will be sent to approver" : "Verify failed, this account has been verified";
            }
            return View("EmailResponse");
        }

        [AllowAnonymous]
        public async Task<ActionResult> ApprovalCustomer(int id)
        {
            ViewBag.EmailResponseMsg = "";
            if (Request.UserHostAddress != POSCO_MAIL_ADDRESS)
            {
                var result = await _customerService.ApprovalCustomer(id);
                ViewBag.EmailResponseMsg = result ? "Approval successful, an email will be sent to this customer" : "Approval failed, this account has been approved";
            }
            return View("EmailResponse");
        }
    }
}