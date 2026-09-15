using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
namespace InventoryByawAstha.Domain.Entities
{

    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string UserEmail { get; set; } = string.Empty;
        public string HashPassword { get; set; } = string.Empty;
        public string UserPhoneNumber { get; set; } = string.Empty;
        public string UserRole { get; set; } = "User";
        public bool IsActive { get; set; } = true;
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}