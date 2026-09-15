using InventoryByawAstha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.DAL.Configurations
{
    public class PurchaseConfigurtaion:IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder) {
            builder.ToTable("purchase");
            builder.HasKey(p => p.PurchaseId);
            builder.Property(p => p.PurchaseId).HasColumnName("id");
                  
            builder.Property(p => p.PurchaseDate).HasColumnName("purchase_date")
            .IsRequired();      
            builder.Property(p => p.VendorId).HasColumnName("vendor_id");       

            builder.Property(p => p.UserId).HasColumnName("customer_id");
            builder.HasOne(p => p.Vendor).WithMany(v => v.Purchases).HasForeignKey(p => p.VendorId)       
            .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);       
            builder.HasMany(p => p.PurchaseDetails).WithOne(pd => pd.Purchase)
            .HasForeignKey(pd => pd.PurchaseId).OnDelete(DeleteBehavior.Cascade);
                   
         }           
              
    }
}
            

            
                   
                   
                   

            
                   
                   
                   
           

          
