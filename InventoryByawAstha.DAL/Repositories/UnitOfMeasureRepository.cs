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
    public class UnitOfMeasureRepository:IUnitOfMeasureRepository
    {
        private readonly InventoryByawAsthaDbContext context;
        public UnitOfMeasureRepository(InventoryByawAsthaDbContext context) {
            this.context = context;
}
        public async Task<List<UnitofMeasure>> GetAll() {
            return await context.UnitsofMeasure.ToListAsync();
        
        }

        public async Task<UnitofMeasure?> GetById(int id)
        {
            return await context.UnitsofMeasure
                 .FirstOrDefaultAsync(uom => uom.UnitofMeasureId == id);

        }

        public async Task Create(UnitofMeasure unitOfMeasure)
        {
            await context.UnitsofMeasure.AddAsync(unitOfMeasure);
            await context.SaveChangesAsync();
        }

        public async Task Update(UnitofMeasure unitOfMeasure)
        {
            context.UnitsofMeasure.Update(unitOfMeasure);
            await context.SaveChangesAsync();
        }
    
        public async Task<bool> Exists(string unitName, int unitId) {
            return await context.UnitsofMeasure.AnyAsync(uom => uom.Name == unitName && uom.UnitofMeasureId != unitId);
        
        }
        public async Task<bool> CodeExists(string code, int unitId) {
            return await context.UnitsofMeasure.AnyAsync(uom => uom.Code == code && uom.UnitofMeasureId != unitId);
        }




    }
}
