using InventoryByawAstha.BLL.src.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.Interfaces.Services
{
    public interface IProductService
    {
        public Task<List<ProductDTO>> GetAll();
        public Task<ProductDTO> GetById(int id);
        public Task Create(CreateProductDTO dto,int UserId);
        public Task Update(UpdateProductDTO dto);
        public Task Delete(int id);
        public Task<List<CurrentStockDTO>> GetCurrentStocks();
    }
}
