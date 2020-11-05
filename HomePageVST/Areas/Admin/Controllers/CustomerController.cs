using DTO;
using HomePageVST.Extensions.AntiModelInjection;
using Services.Interfaces;
using System;
using System.Net;
using System.Web.Mvc;

namespace HomePageVST.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;

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
    }
}