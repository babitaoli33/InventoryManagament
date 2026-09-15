using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryByawAstha.Domain.Entities;

namespace InventoryByawAstha.DAL.Data
{
public class InventoryByawAsthaDbContext:DbContext
    {
        public InventoryByawAsthaDbContext(DbContextOptions<InventoryByawAsthaDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
        public DbSet<UnitofMeasure> UnitsofMeasure { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<UserPermission> UserPermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryByawAsthaDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
