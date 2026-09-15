using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryByawAstha.BLL.src.DTOs.ProductGroupDTOs;

namespace InventoryByawAstha.BLL.src.Interfaces.Services
{
    public interface IProductGroupService
    {
        Task<List<ProductGroupDTO>> GetAll();
        Task<ProductGroupDTO> GetById(int id);
        Task Create(CreateProductGroupDTO dto, int UserId);
        Task Update(UpdateProductGroupDTO dto);
        
    }
}
