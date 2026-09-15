using InventoryByawAstha.Web.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryByawAstha.Web.Controllers.MVC
{
    
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create() {
            return View();
        }
        public IActionResult Edit(int id) {
            var model = new ProductEditViewModel {
                ProductId = id
            };
            return View(model);
        
        }
        public IActionResult CurrentStocks() {
            return View();
        }
    }
}
