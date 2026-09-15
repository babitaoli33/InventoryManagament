using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryByawAstha.Domain.Entities;

namespace InventoryByawAstha.BLL.src.Interfaces.Repositories
{
    public interface IProductGroupRepository
    {
        Task<List<ProductGroup>> GetAllProductGroups();
        Task<ProductGroup?> GetProductGroupById(int id);
        Task CreateProductGroup(ProductGroup productGroup);
        Task UpdateProductGroup(ProductGroup productGroup);
        Task<bool> ProductGroupExists(string name,int id);
    }
}
