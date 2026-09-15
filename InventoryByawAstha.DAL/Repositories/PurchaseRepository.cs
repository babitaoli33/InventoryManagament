using InventoryByawAstha.BLL.src.Interfaces.Repositories;
using InventoryByawAstha.DAL.Data;
using InventoryByawAstha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.DAL.Repositories
{
    public class PurchaseRepository:IPurchaseRepository
    {
        private readonly InventoryByawAsthaDbContext context;
        public PurchaseRepository(InventoryByawAsthaDbContext context) {
            this.context = context;
        }
        public async Task Create(Purchase purchase) {
            await context.Purchases.AddAsync(purchase);
        }
        public async Task<List<Purchase>> GetAll() {
            return await context.Purchases.Include(p=>p.Vendor).Include(p=>p.User).ToListAsync();
        }
        public async Task<Purchase?> GetById(int id) {
            return await context.Purchases.Include(p => p.User).Include(p => p.Vendor)
                   .Include(p => p.PurchaseDetails).ThenInclude(pd => pd.Product)
                   .FirstOrDefaultAsync(p=>p.PurchaseId==id);
        }
    }
}
