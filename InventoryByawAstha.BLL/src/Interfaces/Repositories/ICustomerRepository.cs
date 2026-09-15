using InventoryByawAstha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        public Task<List<Customer>> GetAll();
        public Task<Customer?> GetById(int id);
        public Task Create(Customer customer);
        public Task Update(Customer customer);
        public Task<bool> PhoneNumberExists(string phoneNumber,int customerId);
    }
}
