using InventoryByawAstha.BLL.Exceptions;
using InventoryByawAstha.BLL.Exceptions.GeneralExceptions;
using InventoryByawAstha.BLL.src.DTOs.UnitofMeasureDTOs;
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
    public class UnitofMeasureService : IUnitOfMeasureService
    {
        private readonly IUnitOfMeasureRepository UnitOfMeasureRepo;
        public UnitofMeasureService(IUnitOfMeasureRepository UnitOfMeasureRepo)
        {
            this.UnitOfMeasureRepo = UnitOfMeasureRepo;
            
        }
        public async Task Create(CreateUomDTO dto)
        {
            var unitName = dto.Name.Trim();
            var unitExists = await UnitOfMeasureRepo.Exists(unitName,0);
            if (unitExists) { throw new UnitAlreadyExistsException(unitName); }
            var codeName = dto.Code.Trim();
            var codeExists = await UnitOfMeasureRepo.CodeExists(codeName, 0);
            if(codeExists){ throw new CodeNameAlreadyInUseException(codeName); }
            var UnitOfMeasureObj = new UnitofMeasure { 
            Name=dto.Name,
            Description=dto.Description,
            Code=dto.Code,
            IsActive=dto.IsActive
            
           };
            await UnitOfMeasureRepo.Create(UnitOfMeasureObj);
          }  
           
       public async Task<List<UomDTO>>GetAll()
        {
            var UnitsOfMeasure = await UnitOfMeasureRepo.GetAll();
           return UnitsOfMeasure.Select(uom => new UomDTO { 
            UnitOfMeasureId= uom.UnitofMeasureId,
            Name=uom.Name,
            Description=uom.Description,
            IsActive=uom.IsActive,
            Code=uom.Code
            }).ToList();
               
        }       
          public async Task<UomDTO> GetById(int id)
        {
            var UnitOfMeasureObj = await UnitOfMeasureRepo.GetById(id);
            if (UnitOfMeasureObj == null) {
                throw new UnitofMeasureNotFoundException(id);
            }
            return new UomDTO { 
           UnitOfMeasureId=UnitOfMeasureObj.UnitofMeasureId,
           Name=UnitOfMeasureObj.Name,
           Code=UnitOfMeasureObj.Code,
           Description=UnitOfMeasureObj.Description,
           IsActive=UnitOfMeasureObj.IsActive
            };
            
           }
       public async Task Update(UpdateUomDTO dto)
        {
            var unitName = dto.Name.Trim();
            var unitExists = await UnitOfMeasureRepo.Exists(unitName, dto.UnitOfMeasureId);
            if (unitExists) { throw new UnitAlreadyExistsException(unitName); }
            var codeName = dto.Code.Trim();
            var codeExists = await UnitOfMeasureRepo.CodeExists(codeName, dto.UnitOfMeasureId);
            if (codeExists) { throw new CodeNameAlreadyInUseException(codeName); }
            var UnitOfMeasureObj = await UnitOfMeasureRepo.GetById(dto.UnitOfMeasureId);
            if (UnitOfMeasureObj== null){
                throw new UnitofMeasureNotFoundException(dto.UnitOfMeasureId);
            }
            UnitOfMeasureObj.Name = dto.Name;
            UnitOfMeasureObj.Description = dto.Description;
            UnitOfMeasureObj.Code = dto.Code;
            UnitOfMeasureObj.IsActive = dto.IsActive;
            await UnitOfMeasureRepo.Update(UnitOfMeasureObj);
        }
    }
}

        

      

 