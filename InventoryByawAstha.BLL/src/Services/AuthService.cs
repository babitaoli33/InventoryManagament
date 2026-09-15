using InventoryByawAstha.BLL.Exceptions;
using InventoryByawAstha.BLL.Exceptions.GeneralExceptions;
using InventoryByawAstha.BLL.src.DTOs.AuthDTOs;
using InventoryByawAstha.BLL.src.Interfaces.Repositories;
using InventoryByawAstha.BLL.src.Interfaces.Services;
using InventoryByawAstha.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace InventoryByawAstha.BLL.src.Services
{
    public class AuthService : IAuthService
    {
     
        private readonly IUserRepository userRepository;
        private readonly IRefreshTokenRepository refreshTokenRepository;
        private readonly IConfiguration configuration;
        public AuthService(IUserRepository userRepository,IRefreshTokenRepository refreshTokenRepository,IConfiguration configuration) {
            this.userRepository = userRepository;
            this.refreshTokenRepository = refreshTokenRepository;
            this.configuration = configuration;
        }

        private string GenerateRefreshToken()
        {
            var randomBytes = RandomNumberGenerator.GetBytes(64);
            return Convert.ToBase64String(randomBytes).Replace("+", "-").Replace("/", "_")
            .Replace("=", "");
        }
        private string HashRefreshToken(string refreshToken)
        {
            var bytes = Encoding.UTF8.GetBytes(refreshToken);
            var hash = SHA256.HashData(bytes);
            return Convert.ToBase64String(hash);

        }
        private string GenerateAccessToken(User user) {
          var claims = new List<Claim>{
          new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
          new Claim(ClaimTypes.Name,user.UserName)
         };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expirationMinutes = configuration.GetValue<int>("Jwt:ExpirationMinutes");
            var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
            signingCredentials: credentials
            );
           return new JwtSecurityTokenHandler().WriteToken(token);
            
}
        private async Task<string> CreateRefreshToken(User user) {
            var refreshToken = GenerateRefreshToken();
            var refreshTokenHash = HashRefreshToken(refreshToken);
            var refreshTokenEntity = new RefreshToken
            {
                UserId = user.UserId,
                TokenHash = refreshTokenHash,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(7)
            };
            await refreshTokenRepository.Add(refreshTokenEntity);
            return refreshToken;
        }
        
        public async Task<LoginResponseDTO> Login(LoginDTO dto)
        {
            var user = await userRepository.GetUserByEmail(dto.Email);
            if (user == null)
            {
             throw new InvalidCredentialsException();     
             }   
            if (!user.IsActive)
            {
            throw new UserInactiveException();
            }        
        var isPasswordCorrect = BCrypt.Net.BCrypt.Verify( dto.Password,user.HashPassword);              
         if (!isPasswordCorrect)
            {
                throw new InvalidCredentialsException(); 
            }

            var accessToken = GenerateAccessToken(user);
            var refreshToken = await CreateRefreshToken(user);
            return new LoginResponseDTO {
            AccessToken=accessToken,
            RefreshToken=refreshToken
            };
        }

        public async Task<LoginResponseDTO> RefreshToken(string refreshToken) {
            var tokenHash = HashRefreshToken(refreshToken);
            var storedToken = await refreshTokenRepository.GetByHash(tokenHash);
            if (storedToken == null) {
                throw new InvalidCredentialsException();
            }
            if (storedToken.RevokedAt != null) {
                throw new InvalidCredentialsException();
            }
            if (!storedToken.User.IsActive) {
                throw new UserInactiveException();
            }
            if (storedToken.ExpiresAt <= DateTime.UtcNow) {
                throw new InvalidCredentialsException();
            }
            await refreshTokenRepository.Revoke(storedToken);
            var accessToken = GenerateAccessToken(storedToken.User);
            var NewRefreshToken = await CreateRefreshToken(storedToken.User);
            return new LoginResponseDTO { 
            AccessToken=accessToken,
            RefreshToken=NewRefreshToken
            };
        
        }
        
    }               
                
}            


           


           
       
   
