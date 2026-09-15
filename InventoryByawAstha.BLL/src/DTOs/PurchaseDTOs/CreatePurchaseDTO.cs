using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.DTOs.PurchaseDTOs
{
    public class CreatePurchaseDTO
    {
        public int VendorId { get; set; }
        public List<CreatePurchaseDetailsDTO> Items { get; set; } = new();
    }
}
