using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InventoryByawAstha.Domain.Entities;
namespace InventoryByawAstha.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(u => u.UserId);
            builder.Property(u => u.UserId).HasColumnName("id");
            builder.Property(u => u.UserName).HasColumnName("username").HasMaxLength(100)
            .IsRequired();
            builder.Property(u => u.UserEmail).HasColumnName("email").HasMaxLength(100)
            .IsRequired();
            builder.Property(u => u.HashPassword).HasColumnName("password").IsRequired();
            builder.Property(u => u.UserPhoneNumber).HasColumnName("phonenumber")
             .HasMaxLength(10);
            builder.Property(u => u.UserRole).HasColumnName("role").HasMaxLength(50)
            .HasDefaultValue("User");
            builder.Property(u => u.IsActive).HasColumnName("status").HasDefaultValue(true);
            builder.HasIndex(u => u.UserEmail).IsUnique();
            builder.HasIndex(u => u.UserPhoneNumber).IsUnique();
            /* 
         yedi euta kunai  entity ma foreign key nai xaina vane no need to 
            define relationship

         */

        }
    }
}































