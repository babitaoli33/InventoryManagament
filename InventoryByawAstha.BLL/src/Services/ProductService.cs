using InventoryByawAstha.BLL.Exceptions;
using InventoryByawAstha.BLL.Exceptions.GeneralExceptions;
using InventoryByawAstha.BLL.src.DTOs.ProductDTOs;
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
    public class ProductService:IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IUserRepository userRepository;
        private readonly IUnitOfMeasureRepository unitOfMeasureRepository;
        private readonly IProductGroupRepository productGroupRepository;
        public ProductService(IProductRepository productRepository, 
            IUserRepository userRepository, IUnitOfMeasureRepository unitOfMeasureRepository,
            IProductGroupRepository productGroupRepository)
        {
            this.productRepository = productRepository;
            this.userRepository = userRepository;
            this.unitOfMeasureRepository = unitOfMeasureRepository;
            this.productGroupRepository = productGroupRepository;
        }
        public async Task<List<ProductDTO>> GetAll() {
            var products = await productRepository.GetAll();
           return products.Select(p => new ProductDTO { 
            ProductId=p.ProductId,
            Name=p.Name,
            Description=p.Description,
            ProductGroupName=p.ProductGroup.Name,
            UnitofMeasureName=p.UnitofMeasure.Name,
            ProductGroupId=p.ProductGroupId,
            UnitOfMeasureId=p.UnitOfMeasureId,
            CreatedBy=p.User.UserName,
            IsActive=p.IsActive,
            CreatedDate=p.CreatedAt,
            Quantity=p.Quantity
            
            }).ToList();
        }
        public async Task<ProductDTO> GetById(int id) {
            var product = await productRepository.GetById(id);
            if (product == null) {
                throw new ProductNotFoundException(id);
            }
            return new ProductDTO { 
            ProductId=product.ProductId,
            Name=product.Name,
            Description=product.Description,
            ProductGroupName=product.ProductGroup.Name,
            ProductGroupId=product.ProductGroupId,
            UnitOfMeasureId=product.UnitOfMeasureId,
            UnitofMeasureName=product.UnitofMeasure.Name,
            CreatedBy=product.User.UserName,
            Quantity=product.Quantity,
            IsActive=product.IsActive
            };
        
        }
        public async Task Create(CreateProductDTO dto,int UserId)
        {
            var productGroup = await productGroupRepository.GetProductGroupById(dto.ProductGroupId);
            if (productGroup == null)
            {
                throw new ProductGroupNotFoundException(dto.ProductGroupId);
            }
            var unitOfMeasure = await unitOfMeasureRepository.GetById(dto.UnitofMeasureId);
            if (unitOfMeasure == null) {
                throw new UnitofMeasureNotFoundException(dto.UnitofMeasureId);
            }
            var product = new Product { 
            Name=dto.Name,
            Description=dto.Description,
            ProductGroupId=dto.ProductGroupId,
            UnitOfMeasureId=dto.UnitofMeasureId,
            UserId=UserId,
            IsActive=dto.IsActive,
            CreatedAt=DateTime.UtcNow
          
            };

            await productRepository.Create(product);
        }
        public async Task Update(UpdateProductDTO dto) {
            var product = await productRepository.GetById(dto.ProductId);
            if (product == null) {
                throw new ProductNotFoundException(dto.ProductId);
            }
            var productGroup = await productGroupRepository.GetProductGroupById(dto.ProductGroupId);
            if (productGroup == null) {
                throw new ProductGroupNotFoundException(dto.ProductGroupId);
            }
            var unitOfMeasure = await unitOfMeasureRepository.GetById(dto.UnitofMeasureId);
            if (unitOfMeasure == null) {
                throw new UnitofMeasureNotFoundException(dto.UnitofMeasureId);
            }
            product.Name = dto.Name;
            product.Description = dto.Description;
            product.IsActive = dto.IsActive;
            product.UnitOfMeasureId = dto.UnitofMeasureId;
            product.ProductGroupId = dto.ProductGroupId;
            await productRepository.Update(product);

        }
        public async Task Delete(int id) {
            var product = await productRepository.GetById(id);
            if (product == null) {
                throw new ProductNotFoundException(id);
            }
            await productRepository.Delete(product);
        
        }
        public async Task<List<CurrentStockDTO>> GetCurrentStocks() {
            var products = await productRepository.GetAll();
            return products.Select(p => new CurrentStockDTO {
                ProductId = p.ProductId,
                ProductName = p.Name,
                ProductGroupName = p.ProductGroup.Name,
                UnitName = p.UnitofMeasure.Name,
                Quantity = p.Quantity,
                Status = p.Quantity == 0 ? "Out Of Stock" :p.Quantity<=5?"Low Stock":"In Stock"
                }).ToList();

        }
    }
}
            
        

