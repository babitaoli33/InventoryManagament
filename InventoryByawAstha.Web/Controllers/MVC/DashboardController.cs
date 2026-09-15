using InventoryByawAstha.BLL.src.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryByawAstha.Web.Controllers.MVC
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            this.dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            var dashboard = await dashboardService.GetDashboard();

            return View(dashboard);
        }
    }
}
