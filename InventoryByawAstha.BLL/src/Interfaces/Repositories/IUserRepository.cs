using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryByawAstha.Domain.Entities;
namespace InventoryByawAstha.BLL.src.Interfaces.Repositories
{
   public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User?> GetUserById(int id);
        Task<User?> GetUserByEmail(string Email); 
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task <int> CountActiveAdmins();
        Task<bool> UserEmailExists(string Email,int userId);
        Task<bool> UserPhoneNumberExists(string PhoneNumber, int userId);
       


    }
}
