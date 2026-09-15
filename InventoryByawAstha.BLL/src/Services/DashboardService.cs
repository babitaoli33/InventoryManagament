using InventoryByawAstha.BLL.src.DTOs.DashboardDTOs;
using InventoryByawAstha.BLL.src.Interfaces.Repositories;
using InventoryByawAstha.BLL.src.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.Services
{
    public class DashboardService:IDashboardService
    {
        private readonly IDashboardRepository dashboardRepository;
        public DashboardService(IDashboardRepository dashboardRepository) {
            this.dashboardRepository = dashboardRepository;
        }
        public async Task<DashboardDTO> GetDashboard() {

           var _totalUsers = await dashboardRepository.GetTotalUsers();
           var _totalCustomers = await dashboardRepository.GetTotalCustomers();
           var _totalVendors = await dashboardRepository.GetTotalVendors();
           var _totalProducts = await dashboardRepository.GetTotalProducts();
           var _totalPurchases = await dashboardRepository.GetTotalPurchases();
           var _totalSales = await dashboardRepository.GetTotalSales();
           var _totalPurchaseAmount = await dashboardRepository.GetTotalPurchaseAmount();
            var _totalSalesAmount = await dashboardRepository.GetTotalSalesAmount();
           var _inStockProducts = await dashboardRepository.InStock();
           var _lowStockProducts = await dashboardRepository.GetLowStockProducts();
           var _outOfStockProducts = await dashboardRepository.GetOutOfStockProducts();
           var _totalStock = await dashboardRepository.GetTotalStock();
           var _recentPurchases = await dashboardRepository.GetRecentPurchases();
           var _recentSales = await dashboardRepository.GetRecentSales();
            return new DashboardDTO {
            InStockProducts= _inStockProducts,
            TotalProducts= _totalProducts,
            TotalVendors=_totalVendors,
            TotalSales=_totalSales,
            LowStockProducts=_lowStockProducts,
            OutOfStockProducts=_outOfStockProducts,
            TotalStock=_totalStock,
            TotalCustomers=_totalCustomers,
            TotalPurchases=_totalPurchases,
            TotalUsers=_totalUsers,
            TotalPurchaseAmount=_totalPurchaseAmount,
            TotalSalesAmount=_totalSalesAmount,
            RecentPurchases=_recentPurchases.Select(p=>new RecentPurchaseDTO { 
            PurchaseDate=p.PurchaseDate,
            PurchaseId=p.PurchaseId,
            TotalAmount=p.TotalAmount,
            VendorName=p.Vendor.Name!=null?p.Vendor.Name:"-"
            }).ToList(),
            RecentSales=_recentSales.Select(s=>new RecentSalesDTO {
            CustomerName=s.Customer.Name!=null?s.Customer.Name:"-",
            SaleDate=s.SaleDate,
            SaleId=s.SaleId,
            TotalAmount=s.TotalAmount
            }).ToList()
            };
            
        
        }
    }
}
