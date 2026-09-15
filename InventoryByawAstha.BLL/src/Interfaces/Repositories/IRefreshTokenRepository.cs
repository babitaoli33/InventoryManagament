using InventoryByawAstha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.Interfaces.Repositories
{
    public interface IRefreshTokenRepository
    {
        public Task Add(RefreshToken refreshToken);
        public Task<RefreshToken?> GetByHash(string tokenHash);
        public Task Revoke(RefreshToken refreshToken);
    }
}
