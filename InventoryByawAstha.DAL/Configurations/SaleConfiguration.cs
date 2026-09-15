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
    public class SaleConfiguration
       : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("sale");
            builder.HasKey(s => s.SaleId);
            builder.Property(s => s.SaleId).HasColumnName("id");
            builder.Property(s => s.SaleDate).HasColumnName("sale_date").IsRequired();
            builder.Property(s => s.CustomerId).HasColumnName("customer_id");
            builder.Property(s => s.UserId).HasColumnName("createdby_user_id");
            builder.Property(s => s.TotalAmount).HasPrecision(18, 2);
            builder.HasOne(s => s.Customer).WithMany(c => c.Sales)
            .HasForeignKey(s => s.CustomerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.User).WithMany().HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Restrict);      
            builder.HasMany(s => s.SaleDetails).WithOne(sd => sd.Sale).HasForeignKey(sd => sd.SaleId)
            .OnDelete(DeleteBehavior.Cascade);       
                   
        }
    }
}            
            

                   
                   

  
                   
                 
            
                   


            
                   


           
            
                   
                   
                   



      
           
                 



           
         


