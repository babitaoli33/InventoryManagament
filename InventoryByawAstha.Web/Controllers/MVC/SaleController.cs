using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryByawAstha.Web.Controllers.MVC
{
    
    public class SaleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create() {
            return View();
        }
        public IActionResult Details(int id) {
            return View();
        }
    }
}
