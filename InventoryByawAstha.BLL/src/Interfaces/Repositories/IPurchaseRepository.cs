using InventoryByawAstha.BLL.src.DTOs.PurchaseDTOs;
using InventoryByawAstha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.Interfaces.Repositories
{
   public interface IPurchaseRepository
    {
        public Task Create(Purchase purchase);
        public Task<List<Purchase>> GetAll();
        public Task<Purchase?> GetById(int id);
    }
}
