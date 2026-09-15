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
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>  
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder) {
            builder.ToTable("refresh_token");
            builder.HasKey(r => r.RefreshTokenId);
            builder.Property(r => r.RefreshTokenId).HasColumnName("id");
            builder.Property(r => r.CreatedAt).HasColumnName("created_at");
            builder.Property(r => r.ExpiresAt).HasColumnName("expires_at");
            builder.Property(r => r.RevokedAt).HasColumnName("revoked_at");
            builder.Property(r => r.TokenHash).HasColumnName("token_hash");
            builder.Property(r => r.UserId).HasColumnName("user_id");
            builder.HasOne(r => r.User).WithMany(u => u.RefreshTokens)
                .HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Cascade);
        
        }

     
    }
}
