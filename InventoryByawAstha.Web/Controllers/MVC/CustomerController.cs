using InventoryByawAstha.Web.ViewModels.Customer;
using Microsoft.AspNetCore.Mvc;

namespace InventoryByawAstha.Web.Controllers.MVC
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Edit(int id) {
            var model = new CustomerEditViewModel {
            CustomerId=id
            };
            return View(model);
        
        }
        public IActionResult Create() {
            return View();
        }
    }
}
