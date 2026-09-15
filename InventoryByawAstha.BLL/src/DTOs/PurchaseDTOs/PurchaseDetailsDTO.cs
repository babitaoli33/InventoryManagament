using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.DTOs.PurchaseDTOs
{
    public class PurchaseDetailsDTO
    {
        public int PurchaseDetailId { get; set; }
        public int PurchaseId { get; set; }
        public string Vendor { get; set; }
        public string CreatedBy { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal Amount { get; set; }

        
    }
}

        
       
      
