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
    public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder) {
            builder.ToTable("vendor");
            builder.HasKey(v => v.VendorId);
            builder.Property(v => v.VendorId).HasColumnName("id");
            builder.Property(v => v.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
            builder.Property(v => v.Description) .HasColumnName("description")
            .HasMaxLength(200) .IsRequired();         
            builder.Property(v => v.IsActive).HasColumnName("status").HasDefaultValue(true);
            builder.Property(v => v.UserId).HasColumnName("createdby_user_id");
            builder.HasOne(v => v.User).WithMany().HasForeignKey(v => v.UserId)
            .OnDelete(DeleteBehavior.Restrict);  
          
            
     
                   /*euta vendor ta euta particular user 
                        le banako hunxa tara euta user le multiple
                          vendor haru banauna sakxa                                                      
                                                    */
         }            
    }
}        
              
                   

              
                   
                  


           
                   
                  


           
                   


                 
                   
                   


                
                   


