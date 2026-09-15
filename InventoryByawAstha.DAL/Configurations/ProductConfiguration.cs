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
public class ProductConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder) {
            builder.ToTable("product");
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductId).HasColumnName("id");
            builder.Property(p => p.Name) .HasColumnName("name").HasMaxLength(200).IsRequired();
            builder.Property(p => p.Description).HasColumnName("description").HasMaxLength(500).IsRequired();   
            builder.Property(p => p.IsActive).HasColumnName("status").HasDefaultValue(true);    
            builder.Property(p => p.ProductGroupId).HasColumnName("product_group_id");
            builder.Property(p => p.UnitOfMeasureId).HasColumnName("unit_of_measure_id");
            builder.Property(p => p.UserId).HasColumnName("createdby_user_id");
            builder.HasOne(p => p.ProductGroup).WithMany(pg => pg.Products)
                .HasForeignKey(p => p.ProductGroupId) .OnDelete(DeleteBehavior.Restrict);
             builder.HasOne(p => p.UnitofMeasure) .WithMany()
                   .HasForeignKey(p => p.UnitOfMeasureId)
                   .OnDelete(DeleteBehavior.Restrict);

             builder.HasOne(p => p.User)
                   .WithMany()
                   .HasForeignKey(p => p.UserId)
                   .OnDelete(DeleteBehavior.Restrict);  
                
                 }       
    }

}

                      
      
                   
                   
        
            
                   
           



     
           


         
           

                


           
                     
               
                


            
                  
                  



                   


