using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.DTOs.DashboardDTOs
{
    public class RecentPurchaseDTO
    {
        public int PurchaseId { get; set; }
        public string VendorName { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
