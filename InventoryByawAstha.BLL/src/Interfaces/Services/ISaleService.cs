using InventoryByawAstha.BLL.src.DTOs.SalesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.Interfaces.Services
{
    public interface ISaleService
    {
        public Task<List<SalesDTO>> GetAll();
        public Task<SalesDTO> GetById(int id);
        public Task Create(CreateSalesDTO dto, int UserId);
    }
}
