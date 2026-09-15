using InventoryByawAstha.BLL.src.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryByawAstha.DAL.Data;
using InventoryByawAstha.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryByawAstha.DAL.Repositories
{
    public class ProductGroupRepository:IProductGroupRepository
    {
        private readonly InventoryByawAsthaDbContext context;
        public ProductGroupRepository(InventoryByawAsthaDbContext context) {
            this.context = context;
        }
        public async Task<List<ProductGroup>> GetAllProductGroups() {
            return await context.ProductGroups.Include(pg=>pg.User).ToListAsync();
        }
        public async Task<ProductGroup?> GetProductGroupById(int id) {
            return await context.ProductGroups.FirstOrDefaultAsync(pg => pg.ProductGroupId == id);
            
        }
        public async Task CreateProductGroup(ProductGroup productGroup) {
            await context.ProductGroups.AddAsync(productGroup);
            await context.SaveChangesAsync();
        }
        public async Task UpdateProductGroup(ProductGroup productGroup) {
            context.ProductGroups.Update(productGroup);
            await context.SaveChangesAsync();
        }
        public async Task<bool> ProductGroupExists(string groupName,int id) {
            return await context.ProductGroups.AnyAsync(pg => pg.Name == groupName && pg.ProductGroupId!=id);
        }
        


    }
}
