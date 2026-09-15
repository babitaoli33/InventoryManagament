using InventoryByawAstha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryByawAstha.DAL.Configurations
{
    public class UserPermissionConfiguration : IEntityTypeConfiguration<UserPermission>
    {
        

        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.ToTable("user_permission");
            builder.HasKey(c => c.UserPermissionId);
            builder.Property(c => c.UserPermissionId).HasColumnName("id");
            builder.Property(c=>c.UserId).HasColumnName("user_id").IsRequired();
            builder.Property(c => c.PermissionName).HasColumnName("permission_name").HasMaxLength(100).IsRequired();
        }
    }
}