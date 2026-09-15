using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.DTOs.SalesDTOs
{
    public class CreateSalesDTO
    {
        public int CustomerId { get; set; }
        public List<CreateSaleDetailsDTO> Items= new List<CreateSaleDetailsDTO>();
    }
}
