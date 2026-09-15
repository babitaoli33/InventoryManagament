using BCrypt.Net;
using InventoryByawAstha.DAL.Data;
using InventoryByawAstha.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryByawAstha.DAL.Seed
{
   public static class DbSeeder
    {
       public static async Task SeedAdmin(InventoryByawAsthaDbContext context)
        {
            if (await context.Users.AnyAsync(u => u.UserRole == "Admin"))
            {
                return;
            }
            var admin = new User
            {
                UserEmail = "admin@gmail.com",
                UserName = "admin",
                UserPhoneNumber = "9800000001",
                UserRole = "Admin",
                HashPassword = BCrypt.Net.BCrypt.HashPassword("CHANGE_ME"),
                IsActive = true
            };

            await context.Users.AddAsync(admin);
            await context.SaveChangesAsync();
        }
    }
}