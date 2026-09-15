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
    public class UnitofMeasureConfiguration : IEntityTypeConfiguration<UnitofMeasure> {
        public void Configure(EntityTypeBuilder<UnitofMeasure> builder) {
            builder.ToTable("unit_of_measure");
 
            builder.HasKey(uom => uom.UnitofMeasureId);
            builder.Property(uom => uom.UnitofMeasureId).HasColumnName("id");
            builder.Property(uom => uom.Name).HasColumnName("name").HasMaxLength(50)
            .IsRequired();        
            builder.Property(uom => uom.Code).HasColumnName("code").HasMaxLength(20)
            .IsRequired();     
            builder.Property(uom => uom.Description).HasColumnName("description").HasMaxLength(100)
             .IsRequired();           
            builder.Property(uom => uom.IsActive).HasColumnName("status").HasDefaultValue(true);          
              
            builder.HasIndex(uom => uom.Code).IsUnique();
            builder.HasIndex(uom => uom.Name).IsUnique();
                     
          }         

    }
}         
            
                   
            
                   
                   
                          


                   
            
                   
           
                 

  