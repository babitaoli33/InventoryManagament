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
  public class ProductRepository:IProductRepository
    {
        private readonly InventoryByawAsthaDbContext context;
        public ProductRepository(InventoryByawAsthaDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Product>> GetAll() {
            return await context.Products.Include(p=>p.ProductGroup)
                .Include(p=>p.UnitofMeasure).Include(p=>p.User).ToListAsync();
        }
        public async Task<Product?> GetById(int id) {
            return await context.Products.Include(p=>p.ProductGroup).Include(p=>p.UnitofMeasure).
           Include(p=>p.User).FirstOrDefaultAsync(p => p.ProductId == id) ;
         }
        public async Task Update(Product product) {
            context.Products.Update(product);
            await context.SaveChangesAsync();
        }
        public async Task Create(Product product)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

        }
        public async Task Delete(Product product) {
             context.Products.Remove(product);
            await context.SaveChangesAsync();
        }

        public async Task<Product?> GetByIdForUpdate(int id) {
            return await context.Products.
            FromSqlInterpolated($@"SELECT * FROM product WHERE id={id} FOR UPDATE").FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetCurrentStocks() {
            return await context.Products.Include(p => p.ProductGroup).Include(p => p.UnitofMeasure).ToListAsync();
        
        }
       
    }
}
