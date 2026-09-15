using InventoryByawAstha.BLL.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using InventoryByawAstha.DAL.Data;
namespace InventoryByawAstha.DAL
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly InventoryByawAsthaDbContext context;
        private IDbContextTransaction? transaction;
        public UnitOfWork(InventoryByawAsthaDbContext context) {
            this.context = context;
        }
        public async Task SaveChangesAsync() {
            await context.SaveChangesAsync();
        }
        
    }
}
