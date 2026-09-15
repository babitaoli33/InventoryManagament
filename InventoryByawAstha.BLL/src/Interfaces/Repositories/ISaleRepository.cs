using InventoryByawAstha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.Interfaces.Repositories
{
    public interface ISaleRepository
    {
        public Task<List<Sale>> GetAll();
        public Task<Sale?> GetById(int id);
        public Task Create(Sale sale);
    }
}
