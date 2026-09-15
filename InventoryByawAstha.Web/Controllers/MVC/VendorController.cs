using InventoryByawAstha.Web.ViewModels.Vendor;
using Microsoft.AspNetCore.Mvc;

namespace InventoryByawAstha.Web.Controllers.MVC
{
    public class VendorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create() {
            return View();
        }
        public IActionResult Edit(int id) {
            var model =  new VendorEditViewModel{ 
            VendorId=id
            };
            return View(model);
        
        }
    }
}
