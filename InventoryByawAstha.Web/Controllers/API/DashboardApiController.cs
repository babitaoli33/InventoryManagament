using InventoryByawAstha.BLL.src.Interfaces.Services;
using InventoryByawAstha.Web.Acl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryByawAstha.Web.Controllers.API
{
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardApiController : ControllerBase
    {
        private readonly IDashboardService dashboardService;
        public DashboardApiController(
            IDashboardService dashboardService)
        {
            this.dashboardService = dashboardService;
        }

        [HttpGet]
        [Authorize(Policy = PermissionList.DashboardView)]
        public async Task<IActionResult> GetDashboard()
        {
            var dashboard =await dashboardService.GetDashboard();
            return Ok(dashboard);   
        }
    }
}


           


