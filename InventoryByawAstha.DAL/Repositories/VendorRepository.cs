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
    public class VendorRepository : IVendorRepository
    {
        private readonly InventoryByawAsthaDbContext context;
        public VendorRepository(InventoryByawAsthaDbContext context) {
            this.context = context;
        }
        public async Task Create(Vendor vendor)
        {
            await context.Vendors.AddAsync(vendor);
            await context.SaveChangesAsync();
        }

        public async Task<List<Vendor>> GetAll()
        {
            return await context.Vendors.Include(v=>v.User).ToListAsync();
        }

        public async Task<Vendor?> GetById(int  id)
        {
            return await context.Vendors.Include(v=>v.User).FirstOrDefaultAsync(v => v.VendorId == id);

        }

        public async Task Update(Vendor vendor)
        {
            context.Vendors.Update(vendor);
            await context.SaveChangesAsync();
        }
        public async Task<bool> Exists(string vendorName, int vendorId) {
            return await context.Vendors.AnyAsync(v=>v.Name==vendorName && v.VendorId!=vendorId );
        
        
        }
    }
}
