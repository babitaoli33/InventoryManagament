using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.DTOs.SalesDTOs
{
    public class SalesDTO
    {
        public int SaleId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime SalesDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<SaleDetailsDTO> SaleDetails { get; set; } = new List<SaleDetailsDTO>();
    }
}
