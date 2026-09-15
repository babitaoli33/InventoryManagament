using InventoryByawAstha.BLL.src.Interfaces.Repositories;
using InventoryByawAstha.DAL.Data;
using InventoryByawAstha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.DAL.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly InventoryByawAsthaDbContext context;
        public DashboardRepository(InventoryByawAsthaDbContext context) {
            this.context = context;
        }
        public async Task<int> GetLowStockProducts()
        {
            return await context.Products.CountAsync(p=>p.Quantity>0 && p.Quantity<=5);
        }
        public async Task<int> GetOutOfStockProducts()
        {
            return await context.Products.CountAsync(p=>p.Quantity==0);
        }
        public async Task<int> GetTotalCustomers()
        {
            return await context.Customers.CountAsync(c=>c.IsActive);
        }
       public async Task<int> GetTotalProducts()
        {
            return await context.Products.CountAsync(p=>p.IsActive);
        }
       public async Task<decimal> GetTotalPurchaseAmount()
        {
            return await context.Purchases.SumAsync(p => (decimal?)p.TotalAmount)??0;
        }
        public async Task<int> GetTotalPurchases()
        {
            return await context.Purchases.CountAsync();
        }
        public async Task<int> GetTotalSales()
        {
            return await context.Sales.CountAsync();
        }
        public async Task<decimal> GetTotalSalesAmount()
        {
            return await context.Sales.SumAsync(s =>(decimal?) s.TotalAmount)??0;
        }
        public async Task<int> GetTotalStock()
        {
            return await context.Products.SumAsync(p => (int?)p.Quantity) ?? 0;
        }
        public async Task<int> GetTotalUsers()
        {
            return await context.Users.CountAsync(u => u.IsActive);
        }
        public async Task<int> GetTotalVendors()
        {
            return await context.Vendors.CountAsync(v => v.IsActive);
        }
        public async Task<int> InStock() {
            return await context.Products.CountAsync(p => p.Quantity > 5);
        }
         public async Task<List<Sale>> GetRecentSales() {
            return await context.Sales.AsNoTracking().Include(s => s.Customer)
            .OrderByDescending(s=>s.SaleDate).Take(2).ToListAsync();
        
        }
       
        public async Task<List<Purchase>> GetRecentPurchases() {
            return await context.Purchases.AsNoTracking()
           .Include(p => p.Vendor).OrderByDescending(p=>p.PurchaseDate).Take(2).ToListAsync();
        }
    }
}
