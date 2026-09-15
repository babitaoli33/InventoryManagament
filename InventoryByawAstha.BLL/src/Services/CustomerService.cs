using InventoryByawAstha.BLL.Exceptions.GeneralExceptions;
using InventoryByawAstha.BLL.src.DTOs.CustomerDTOs;
using InventoryByawAstha.BLL.src.Interfaces;
using InventoryByawAstha.BLL.src.Interfaces.Repositories;
using InventoryByawAstha.BLL.src.Interfaces.Services;
using InventoryByawAstha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IUnitOfWork unitOfWork;
        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            this.customerRepository = customerRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task Create(CreateCustomerDTO dto, int UserId)
        {
            var phoneNumberExists = await customerRepository.PhoneNumberExists(dto.Phone, 0);
            if (phoneNumberExists) { throw new CustomerPhoneNumberExistsException(dto.Phone); }
            var customer = new Customer
            {
                Name = dto.Name,
                Address = dto.Address,
                PhoneNumber = dto.Phone,
                IsActive = dto.IsActive,
                UserId = UserId,
            };
            await customerRepository.Create(customer);
            await unitOfWork.SaveChangesAsync();
        }




        public async Task<List<CustomerDTO>> GetAll()
        {
            var customers = await customerRepository.GetAll();
            return customers.Select(c => new CustomerDTO
            {
                CustomerId = c.CustomerId,
                Name = c.Name,
                Address = c.Address,
                Phone = c.PhoneNumber,
                CreatedBy = c.User.UserName,
                IsActive = c.IsActive
            }).ToList();
        }
        public async Task<CustomerDTO> GetById(int id)
        {
            var customer = await customerRepository.GetById(id);
            if (customer == null) { throw new CustomerNotFoundException(id); }
            return new CustomerDTO
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Address = customer.Address,
                Phone = customer.PhoneNumber,
                CreatedBy = customer.User.UserName,
                IsActive = customer.IsActive
            };
        }
        public async Task Update(UpdateCustomerDTO dto)
        {
            var customer = await customerRepository.GetById(dto.CustomerId);
            if (customer == null) { throw new CustomerNotFoundException(dto.CustomerId); }
            var phoneNumberExists = await customerRepository.PhoneNumberExists(dto.Phone, dto.CustomerId);
            if (phoneNumberExists) { throw new CustomerPhoneNumberExistsException(dto.Phone); }
            customer.Name = dto.Name;
            customer.PhoneNumber = dto.Phone;
            customer.Address = dto.Address;
            customer.IsActive = dto.IsActive;
            await unitOfWork.SaveChangesAsync();

        }
    }
}







