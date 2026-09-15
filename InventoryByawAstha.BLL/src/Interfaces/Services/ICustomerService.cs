using InventoryByawAstha.BLL.src.DTOs.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.Interfaces.Services
{
    public interface ICustomerService
    {
        public Task Create(CreateCustomerDTO dto,int UserId);
        public Task Update(UpdateCustomerDTO dto);
        public Task<List<CustomerDTO>> GetAll();
        public Task<CustomerDTO> GetById(int id);
    }
}
