using InventoryByawAstha.BLL.src.Interfaces.Services;
using InventoryByawAstha.BLL.src.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryByawAstha.Web.Controllers.MVC
{
    public class PurchaseController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create() {
            return View();
        }
        public IActionResult Details( int id,string vendor, string createdBy , DateTime date , decimal totalAmount)
        {
            TempData["PurchaseId"] = id;
            TempData["Vendor"] = vendor;
            TempData["CreatedBy"] = createdBy;
            TempData["PurchaseDate"] = date;
            TempData["TotalAmount"] = totalAmount.ToString("0.00");

            return View();
        }
    }
}
