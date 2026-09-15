using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.DTOs.DashboardDTOs
{
    public class DashboardDTO
    {
        public int TotalProducts { get; set; }
        public int TotalCustomers { get; set; }
        public int TotalVendors { get; set; }
        public int TotalUsers { get; set; } 
        public int TotalSales { get; set; }
        public int TotalPurchases { get; set; }
        public decimal TotalSalesAmount { get; set; }
        public decimal TotalPurchaseAmount { get; set; }
        public int TotalStock { get; set; }
        public int InStockProducts { get; set; }
        public int LowStockProducts { get; set; } 
        public int OutOfStockProducts { get; set; }
        public List<RecentPurchaseDTO> RecentPurchases { get; set; } = new(); 
        public List<RecentSalesDTO> RecentSales { get; set; }= new();
        
            
    }
}
        

        

        
        
        

        


