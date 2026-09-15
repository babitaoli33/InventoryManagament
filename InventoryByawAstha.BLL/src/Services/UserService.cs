using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryByawAstha.Domain.Entities;
using System.Security.Cryptography.X509Certificates;
using InventoryByawAstha.BLL.src.DTOs.UserDTOs;
using InventoryByawAstha.BLL.src.Interfaces.Repositories;
using InventoryByawAstha.BLL.src.Interfaces.Services;
using InventoryByawAstha.BLL.Exceptions;
using System.Xml;
using InventoryByawAstha.BLL.Exceptions.GeneralExceptions;
namespace InventoryByawAstha.BLL.src.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<List<UsersDTO>> GetAllUsers()
        {
            var users = await userRepository.GetAllUsers();
            return users.Select(u => new UsersDTO
            {
                UserId = u.UserId,
                Name = u.UserName,
                PhNumber = u.UserPhoneNumber,
                Email = u.UserEmail,
                Role = u.UserRole,
                IsActive = u.IsActive

            }).ToList();
        }
        public async Task CreateUser(CreateUserDTO dto)
        {
            var phNumber = dto.PhNumber.Trim();
            var phoneNumberExists = await userRepository.UserPhoneNumberExists(phNumber,0);
            if (phoneNumberExists) { throw new UserPhoneNumberAlreadyInUseException(); }
            var EmailExists = await userRepository.UserEmailExists(dto.Email, 0);
            if (EmailExists) {
                throw new UserEmailAlreadyInUseException();
            }
            
            var user = new User
            {
                UserName = dto.Name,
                UserEmail = dto.Email,
                HashPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                UserPhoneNumber = dto.PhNumber,
                UserRole = dto.Role,
                IsActive = dto.IsActive,

            };

            await userRepository.AddUser(user);
        }
        public async Task<UpdateUserDTO?> GetUserForUpdate(int id)
        {
            var user = await userRepository.GetUserById(id);
            if (user == null)
            {
                throw new UserNotFoundException(id);
            }
            return new UpdateUserDTO
            {
                UserId = user.UserId,
                Name = user.UserName,
                PhNumber = user.UserPhoneNumber,
                Email = user.UserEmail,
                IsActive = user.IsActive,
                Role = user.UserRole

            };
        }
        public async Task UpdateUser(UpdateUserDTO dto)
        {
            var phNumber = dto.PhNumber.Trim();
            var phoneNumberExists = await userRepository.UserPhoneNumberExists(phNumber, dto.UserId);
            if (phoneNumberExists) { throw new UserPhoneNumberAlreadyInUseException(); }
            var EmailExists = await userRepository.UserEmailExists(dto.Email, dto.UserId);
            if (EmailExists) { throw new UserEmailAlreadyInUseException(); }
            var user = await userRepository.GetUserById(dto.UserId);
            if (user == null) { throw new UserNotFoundException(dto.UserId); }
            user.UserEmail = dto.Email;
            user.UserPhoneNumber = dto.PhNumber;
            user.UserName = dto.Name;
            user.UserRole = dto.Role;
            user.IsActive = dto.IsActive;
            await userRepository.UpdateUser(user);

        }
    
        public async Task<UserDetailsDTO>GetUserById(int id)
        {
            var user = await userRepository.GetUserById(id);
            if (user == null)
            {
                throw new UserNotFoundException(id);
            }
            return new UserDetailsDTO
            {
                UserId = user.UserId,
                Email = user.UserEmail,
                PhNumber = user.UserPhoneNumber,
                IsActive = user.IsActive,
                Role = user.UserRole,

            };
        }
        


        
        public async Task ActivateUser(int id)
        {
            var user = await userRepository.GetUserById(id);
            if (user == null)
            {
                throw new UserNotFoundException(id);
            }
            user.IsActive = true;
            await userRepository.UpdateUser(user);
        }
        public async Task DeactivateUser(int id)
        {
            var user = await userRepository.GetUserById(id);
            if (user == null)
            {
                throw new UserNotFoundException(id);
            }
            if (user.UserRole == "Admin" && user.IsActive) {
                var activeAdmins = await userRepository.CountActiveAdmins();
                if (activeAdmins <= 1) {
                    throw new LastAdminException();
                }
            
            }
            user.IsActive = false;
            await userRepository.UpdateUser(user);
        }
       
    }
} 
