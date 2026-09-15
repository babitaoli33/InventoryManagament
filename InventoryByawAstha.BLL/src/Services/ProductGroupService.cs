using InventoryByawAstha.BLL.src.Interfaces.Repositories;
using InventoryByawAstha.BLL.src.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryByawAstha.BLL.src.DTOs.ProductGroupDTOs;
using InventoryByawAstha.BLL.Exceptions;
using System.Security.Cryptography.X509Certificates;
using InventoryByawAstha.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using InventoryByawAstha.BLL.Exceptions.GeneralExceptions;

namespace InventoryByawAstha.BLL.src.Services
{
   public class ProductGroupService:IProductGroupService
    {
        private readonly IProductGroupRepository productGroupRepo;
        public ProductGroupService(IProductGroupRepository productGroupRepo) {
            this.productGroupRepo = productGroupRepo;
        }
        public async Task<List<ProductGroupDTO>> GetAll() {
            var productGroups = await productGroupRepo.GetAllProductGroups();
            return productGroups.Select(pg => new ProductGroupDTO
            {
            ProductGroupId=pg.ProductGroupId,
            Name=pg.Name,
            Description=pg.Description,
            IsActive=pg.IsActive,
            CreatedBy=pg.User!=null?pg.User.UserName:""

            }).ToList();
       }
        public async Task<ProductGroupDTO> GetById(int id) {
            var productGroup = await productGroupRepo.GetProductGroupById(id);
            if(productGroup== null){
                throw new ProductGroupNotFoundException(id);
            }
            return new ProductGroupDTO { 
            Name=productGroup.Name,
            Description=productGroup.Description,
            IsActive=productGroup.IsActive
             };
           
        
        }
        public async Task Create(CreateProductGroupDTO dto, int UserId) {
            var name = dto.Name.Trim();
            var productGroupExists = await productGroupRepo.ProductGroupExists(name, 0);
            if (productGroupExists) { throw new ProductGroupExistsException(name); }
            var productGroup = new ProductGroup { 
            Name=dto.Name,
            Description=dto.Description,
            IsActive=dto.IsActive,
            UserId=UserId
             };
            await productGroupRepo.CreateProductGroup(productGroup);
         }   
        public async Task Update(UpdateProductGroupDTO dto)
        {
            var name = dto.Name.Trim();
            var productGroup = await productGroupRepo.GetProductGroupById(dto.ProductGroupId);

            if (productGroup == null) {
                throw new ProductGroupNotFoundException(dto.ProductGroupId);
            }
            var productGroupExists = await productGroupRepo.ProductGroupExists(name, dto.ProductGroupId);
            if (productGroupExists) { throw new  ProductGroupExistsException(name); }
            productGroup.Name = dto.Name;
            productGroup.Description = dto.Description;
            productGroup.IsActive = dto.IsActive;
            await productGroupRepo.UpdateProductGroup(productGroup);
         }   
        }    
 }

       
        
        
       

        
        
    

