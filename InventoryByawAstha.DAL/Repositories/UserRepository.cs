
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryByawAstha.Domain.Entities;
using InventoryByawAstha.DAL.Data;
using Microsoft.EntityFrameworkCore;
using InventoryByawAstha.BLL.src.Interfaces.Repositories;

namespace InventoryByawAstha.DAL.Repositories
{
   public class UserRepository:IUserRepository
    {
        private readonly InventoryByawAsthaDbContext context;
        public UserRepository(InventoryByawAsthaDbContext context) {
            this.context = context;
        }
        public async Task<List<User>> GetAllUsers() {
            return await context.Users.AsNoTracking().ToListAsync();
        }
        public async Task<User?> GetUserById(int id) {
            return await context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            
        }
        public async Task<User?> GetUserByEmail(string Email) {
            return await context.Users.FirstOrDefaultAsync(u => u.UserEmail == Email);
           }
        public async Task AddUser(User user) {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }
        public async Task UpdateUser(User user) {
             context.Users.Update(user);
            await context.SaveChangesAsync();
        
        }
        public async Task<int> CountActiveAdmins() {
            return await context.Users.CountAsync(u => u.UserRole == "Admin" && u.IsActive);
        }

        public async Task<bool> UserEmailExists(string Email,  int userId) {
            return await context.Users.AnyAsync(u => u.UserEmail == Email && u.UserId != userId);
        }
        public async Task<bool> UserPhoneNumberExists(string PhoneNumber, int userId) {
            return await context.Users.AnyAsync(u => u.UserPhoneNumber == PhoneNumber && u.UserId != userId);
        }
    }
}
