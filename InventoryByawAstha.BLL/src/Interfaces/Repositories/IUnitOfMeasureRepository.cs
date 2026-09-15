using InventoryByawAstha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.Interfaces.Repositories
{
   public interface IUnitOfMeasureRepository
    {
        Task<List<UnitofMeasure>> GetAll();
        Task<UnitofMeasure?> GetById(int id);
        Task Create(UnitofMeasure unitOfMeasure);
        Task Update(UnitofMeasure unitOfMeasure);
        Task<bool> Exists(string unitName, int unitId);
        Task<bool> CodeExists(string code, int unitId);
    }
}
