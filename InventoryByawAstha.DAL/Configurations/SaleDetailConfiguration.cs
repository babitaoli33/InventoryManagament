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
    public class SaleDetailConfiguration: IEntityTypeConfiguration<SaleDetail>
      
    {
        public void Configure(EntityTypeBuilder<SaleDetail> builder)
        {
            builder.ToTable("sale_detail");
            builder.HasKey(sd => sd.SaleDetailId);
            builder.Property(sd => sd.SaleDetailId).HasColumnName("id");
            builder.Property(sd => sd.SaleId).HasColumnName("sale_id");
            builder.Property(sd => sd.ProductId).HasColumnName("product_id");
            builder.Property(sd => sd.Quantity).HasColumnName("quantity").HasPrecision(18, 2)       
            .IsRequired();
            builder.Property(sd => sd.SalesPrice).HasColumnName("sales_price").HasPrecision(18, 2)
            .IsRequired();
            builder.Property(sd => sd.Amount).HasPrecision(18, 2);
            builder.HasOne(sd => sd.Sale).WithMany(s => s.SaleDetails).HasForeignKey(sd => sd.SaleId)
            .OnDelete(DeleteBehavior.Cascade);       
            builder.HasOne(sd => sd.Product).WithMany(p => p.SaleDetails)
            .HasForeignKey(sd => sd.ProductId).OnDelete(DeleteBehavior.Restrict); 
        
        }
    }
}
                 
                   
                  


            
                   


            


            
                   
                   
                   
  
                  

            
                   
                   
                  



          



           
           
                 
