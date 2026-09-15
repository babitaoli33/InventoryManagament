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
    public class PurchaseDetailConfiguration: IEntityTypeConfiguration<PurchaseDetail>
    {
        public void Configure(EntityTypeBuilder<PurchaseDetail> builder) {
            builder.ToTable("purchase_detail");
            builder.HasKey(pd => pd.PurchaseDetailId);
            builder.Property(pd => pd.PurchaseDetailId).HasColumnName("id");
            builder.Property(pd => pd.PurchaseId).HasColumnName("purchase_id");
            builder.Property(pd => pd.ProductId).HasColumnName("product_id");
            builder.Property(pd => pd.Quantity).HasColumnName("quantity");
            builder.Property(pd => pd.PurchasePrice).HasColumnName("purchase_price")
            .HasPrecision(18, 2);
            builder.Property(pd => pd.SalesPrice).HasColumnName("sales_price").HasPrecision(18, 2);
            builder.HasOne(pd => pd.Purchase).WithMany(p => p.PurchaseDetails)       
            .HasForeignKey(pd => pd.PurchaseId).OnDelete(DeleteBehavior.Cascade);       
            builder.HasOne(pd => pd.Product).WithMany(p => p.PurchaseDetails)
            .HasForeignKey(pd => pd.ProductId).OnDelete(DeleteBehavior.Restrict);
            
                        
        }
    }
}           


            
                   


            
                   


            
                   
                   


            
                   



            
                   
                   
                   



           
                   
                   
   
