using InventoryByawAstha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.Interfaces.Repositories
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAll();
        public Task<Product?> GetById(int id);
        public Task Update(Product product);
        public Task Create(Product product);
        public Task Delete(Product product);
        public Task<Product?> GetByIdForUpdate(int id);
        public Task<List<Product>> GetCurrentStocks();
    }

}
