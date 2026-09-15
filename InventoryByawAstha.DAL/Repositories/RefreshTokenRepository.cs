using InventoryByawAstha.BLL.src.Interfaces.Repositories;
using InventoryByawAstha.DAL.Data;
using InventoryByawAstha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.DAL.Repositories
{
    public class RefreshTokenRepository:IRefreshTokenRepository
    {
        private readonly InventoryByawAsthaDbContext context;
        public RefreshTokenRepository(InventoryByawAsthaDbContext context) {
            this.context = context;
            
        }

    public async Task Add(RefreshToken refreshToken)
        {
            context.RefreshTokens.Add(refreshToken);
            await context.SaveChangesAsync();
        }

        public async Task<RefreshToken?> GetByHash(string tokenHash)
        {
            return await context.RefreshTokens.Include(r => r.User)
                .FirstOrDefaultAsync(r=>r.TokenHash==tokenHash);
        }

        public async Task Revoke(RefreshToken refreshToken)
        {
            refreshToken.RevokedAt = DateTime.UtcNow;
            context.RefreshTokens.Update(refreshToken);
            await context.SaveChangesAsync();
        }
    }
}
