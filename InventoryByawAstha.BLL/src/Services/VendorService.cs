using InventoryByawAstha.BLL.Exceptions.GeneralExceptions;
using InventoryByawAstha.BLL.src.DTOs.VendorDTOs;
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
    public class VendorService:IVendorService
    {
        private readonly IVendorRepository vendorRepository;
        public VendorService(IVendorRepository vendorRepository) {
            this.vendorRepository = vendorRepository;
        }

        public async Task Create(CreateVendorDTO dto, int userId)
        {
            var name = dto.Name.Trim();
            var vendorExists = await vendorRepository.Exists(name, 0);
            if (vendorExists) { throw new VendorAlreadyExistsException(name); }
            var vendor = new Vendor { 
            Name=dto.Name,
            Description=dto.Description,
            IsActive=dto.IsActive,
            UserId=userId
            };
            await vendorRepository.Create(vendor);
        }

        public async Task<List<VendorDTO>> GetAll()
        {
            var vendors = await vendorRepository.GetAll();
            return vendors.Select(v => new VendorDTO { 
            VendorId=v.VendorId,
            Name=v.Name,
            Description=v.Description,
            CreatedBy=v.User.UserName,
            IsActive=v.IsActive
            
            }).ToList(); 
        }

        public async Task<VendorDTO> GetById(int id)
        {
            var vendor = await vendorRepository.GetById(id);
            if (vendor == null) {
                throw new VendorNotFoundException(id);
            }
            return new VendorDTO { 
            VendorId=vendor.VendorId,
            Name=vendor.Name,
            Description=vendor.Description,
            IsActive=vendor.IsActive,
            CreatedBy=vendor.User.UserName
            
            };
        }

        public async Task Update(UpdateVendorDTO dto)
        {
            var name = dto.Name.Trim();
            var vendorExists = await vendorRepository.Exists(name, dto.VendorId);
            if (vendorExists) {
                throw new VendorAlreadyExistsException(name);
            }
            var vendor = await vendorRepository.GetById(dto.VendorId);
            if (vendor == null) {
                throw new VendorNotFoundException(dto.VendorId);
            }
            vendor.Name = dto.Name;
            vendor.Description = dto.Description;
            vendor.IsActive = dto.IsActive;
            await vendorRepository.Update(vendor);
            
        }
    }
}
