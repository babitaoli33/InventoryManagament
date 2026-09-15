using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryByawAstha.Web.Controllers.MVC
{
   
    public class UnitOfMeasureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create() {
            return View();
        }
        public IActionResult Update(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
