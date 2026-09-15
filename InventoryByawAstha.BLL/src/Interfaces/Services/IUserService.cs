using InventoryByawAstha.BLL.src.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.Interfaces.Services
{
    public interface IUserService
    {
        public Task<List<UsersDTO>> GetAllUsers();
        public Task<UpdateUserDTO?> GetUserForUpdate(int id);
        public Task CreateUser(CreateUserDTO dto);
        public Task UpdateUser(UpdateUserDTO dto);
        public Task DeactivateUser(int id);
        public Task ActivateUser(int id);
        public Task <UserDetailsDTO>GetUserById(int id);
   
        
   

    }
}
