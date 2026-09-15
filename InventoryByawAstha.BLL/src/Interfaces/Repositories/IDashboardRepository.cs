using InventoryByawAstha.BLL.src.DTOs.DashboardDTOs;
using InventoryByawAstha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.Interfaces.Repositories
{
    public interface IDashboardRepository
    {
        Task<int> GetTotalUsers();
        Task<int> GetTotalCustomers();
        Task<int> GetTotalProducts();
        Task<int> GetTotalVendors();
        Task<int> GetTotalPurchases();
        Task<int> GetTotalSales();
        Task<decimal> GetTotalPurchaseAmount();
        Task<decimal> GetTotalSalesAmount();
        Task<int> InStock();
        Task<int> GetTotalStock();
        Task<int> GetLowStockProducts();
        Task<int> GetOutOfStockProducts();
        Task<List<Sale>> GetRecentSales();
        Task<List<Purchase>> GetRecentPurchases();
        
        

       }
}
    

        

        

        

        

        
 