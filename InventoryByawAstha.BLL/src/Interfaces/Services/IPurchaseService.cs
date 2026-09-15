using InventoryByawAstha.BLL.src.DTOs.PurchaseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.Interfaces.Services
{
    public interface IPurchaseService
    {
        public Task Create(CreatePurchaseDTO dto,int userId);
        public Task<List<PurchaseDTO>> GetAll();
        public Task<List<PurchaseDetailsDTO>> GetById(int purchaseId);
    }
}
