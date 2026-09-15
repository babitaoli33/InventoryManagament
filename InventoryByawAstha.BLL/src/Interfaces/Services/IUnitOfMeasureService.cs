using InventoryByawAstha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryByawAstha.BLL.src.DTOs.UnitofMeasureDTOs;

namespace InventoryByawAstha.BLL.src.Interfaces.Services
{
public interface IUnitOfMeasureService
    {
        public Task<List<UomDTO>> GetAll();
        public Task<UomDTO> GetById(int id);
        public Task Update(UpdateUomDTO dto);
        public Task Create(CreateUomDTO dto);
      

    }
}
