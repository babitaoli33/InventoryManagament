using InventoryByawAstha.BLL.src.DTOs.VendorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.Interfaces.Services
{
    public interface IVendorService
    {
        public Task<List<VendorDTO>> GetAll();
        public Task<VendorDTO> GetById(int id);
        public Task Create(CreateVendorDTO dto,int userId);
        public Task Update(UpdateVendorDTO dto);
        
    }
}
