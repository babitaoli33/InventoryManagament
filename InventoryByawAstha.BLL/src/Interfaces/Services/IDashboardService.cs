using InventoryByawAstha.BLL.src.DTOs.DashboardDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.Interfaces.Services
{
    public interface IDashboardService
    {
        Task<DashboardDTO> GetDashboard();
    }
}
