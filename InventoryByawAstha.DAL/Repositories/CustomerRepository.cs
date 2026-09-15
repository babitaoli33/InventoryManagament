using InventoryByawAstha.BLL.src.Interfaces.Repositories;
using InventoryByawAstha.DAL.Data;
using InventoryByawAstha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly InventoryByawAsthaDbContext context;
        public CustomerRepository(InventoryByawAsthaDbContext context) {
            this.context = context;
        }
        public async Task Create(Customer customer)
        {
            await context.Customers.AddAsync(customer);
           
        }

        public async Task<List<Customer>> GetAll()
        {
            return await context.Customers.Include(c=>c.User).ToListAsync();
        }

        public async Task<Customer?> GetById(int id)
        {
            return await context.Customers.Include(c => c.User).FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        public async Task Update(Customer customer)
        {
            context.Customers.Update(customer);
            
        }
        public async Task<bool> PhoneNumberExists(string phoneNumber,int customerId) {
            return await context.Customers.AnyAsync(c => c.PhoneNumber == phoneNumber && c.CustomerId!=customerId);
        
        }
    }
}
