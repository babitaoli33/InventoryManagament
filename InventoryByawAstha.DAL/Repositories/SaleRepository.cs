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
    public class SaleRepository : ISaleRepository
    {
        private readonly InventoryByawAsthaDbContext context;
        public SaleRepository(InventoryByawAsthaDbContext context) {
            this.context = context;
        }
        public async Task Create(Sale sale)
        {
            await context.Sales.AddAsync(sale);

        }
        public async Task<List<Sale>> GetAll()
        {
            return await context.Sales.Include(s => s.User).Include(s => s.Customer)
                 .Include(s => s.SaleDetails).ThenInclude(sd=>sd.Product).ToListAsync(); 
        }
         public async Task<Sale?> GetById(int id)
        {
            return await context.Sales.Include(s => s.User).Include(s => s.Customer)
                .Include(s => s.SaleDetails).ThenInclude(sd => sd.Product)
                .FirstOrDefaultAsync(s=>s.SaleId==id);
        }

       
    }
}
