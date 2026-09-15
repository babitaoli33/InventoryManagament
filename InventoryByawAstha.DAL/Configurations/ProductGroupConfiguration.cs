using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryByawAstha.Domain.Entities;

namespace InventoryByawAstha.DAL.Configurations
{
    public class ProductGroupConfiguration:IEntityTypeConfiguration<ProductGroup>
    {
        public void Configure(EntityTypeBuilder<ProductGroup> builder) {
            builder.ToTable("product_group");
            builder.HasKey(pg => pg.ProductGroupId);
            builder.Property(pg => pg.ProductGroupId).HasColumnName("id");
            builder.Property(pg => pg.Name).HasColumnName("name").HasMaxLength(100)
            .IsRequired();
            builder.Property(pg => pg.Description).HasColumnName("description").HasMaxLength(200)       
            .IsRequired();
            builder.Property(pg => pg.IsActive).HasColumnName("status").HasDefaultValue(true);
            builder.Property(pg => pg.UserId).HasColumnName("createdby_user_id");       
            builder.HasOne(pg => pg.User).WithMany().HasForeignKey(pg => pg.UserId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(pg => pg.Products).WithOne(p => p.ProductGroup)
            .HasForeignKey(p => p.ProductGroupId).OnDelete(DeleteBehavior.Restrict);
                   
         }
    }
}
          


            
                   
                   
                   


            
                   
                   


            
                  


                   
                   
                   


            
                   
                   
                   

