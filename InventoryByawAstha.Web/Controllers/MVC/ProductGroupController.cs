
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryByawAstha.Web.Controllers.MVC
{
   
    public class ProductGroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

  
        public IActionResult Create()
        {
            return View();
        }



        public IActionResult Edit(int id)
        {
            ViewBag.Id = id;

            return View();
        }

    }
}
