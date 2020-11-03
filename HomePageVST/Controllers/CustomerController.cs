using DTO;
using Services.Interfaces;
using System.Web.Mvc;

namespace HomePageVST.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public ActionResult CreateCustomer(CustomerDTO customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.CreateCustomer(customer);
                return Json(new { Message = "", JsonRequestBehavior.AllowGet });
            }
            else
            {
                return new HttpStatusCodeResult(400);
            }
        }
    }
}