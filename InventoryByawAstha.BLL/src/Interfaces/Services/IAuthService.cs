using InventoryByawAstha.BLL.src.DTOs.AuthDTOs;
using InventoryByawAstha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.Interfaces.Services
{
    public interface IAuthService
    {
        public Task<LoginResponseDTO> Login(LoginDTO dto);
        public Task<LoginResponseDTO> RefreshToken(string refreshToken);
    }
}
