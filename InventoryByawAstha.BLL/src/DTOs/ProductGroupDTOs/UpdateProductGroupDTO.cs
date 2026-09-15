using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.DTOs.ProductGroupDTOs
{
    public class UpdateProductGroupDTO
    {
       public int ProductGroupId { get; set; }
       public string Name { get; set; } = string.Empty;
       public string Description { get; set; } = string.Empty; 
       public bool IsActive { get; set; } 
        

        
    }
}
