using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.DTOs.ProductDTOs
{
   public class UpdateProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ProductGroupId { get; set; }
        public int UnitofMeasureId { get; set; }
        public bool IsActive { get; set; }
    }
}
