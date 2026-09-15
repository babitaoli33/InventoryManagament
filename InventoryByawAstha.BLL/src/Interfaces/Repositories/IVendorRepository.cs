using InventoryByawAstha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.Interfaces.Repositories
{
   public interface IVendorRepository
    {
        public Task<List<Vendor>> GetAll();
        public Task<Vendor?> GetById(int id);
        public Task Create(Vendor vendor);
        public Task Update(Vendor vendor);
        public Task<bool> Exists(string vendorName,int vendorId);
    }
}
