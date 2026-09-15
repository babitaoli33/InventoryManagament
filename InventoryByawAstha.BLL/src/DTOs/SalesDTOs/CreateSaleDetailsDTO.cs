using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.DTOs.SalesDTOs
{
   public class CreateSaleDetailsDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal SalesPrice { get; set; }
    }
}
