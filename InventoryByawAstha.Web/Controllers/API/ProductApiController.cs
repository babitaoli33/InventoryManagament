using InventoryByawAstha.BLL.Exceptions.GeneralExceptions;
using InventoryByawAstha.BLL.src.DTOs.ProductDTOs;
using InventoryByawAstha.BLL.src.Interfaces.Repositories;
using InventoryByawAstha.BLL.src.Interfaces.Services;
using InventoryByawAstha.Domain.Entities;
using InventoryByawAstha.Web.Acl;
using InventoryByawAstha.Web.ApiModel.ProductApiModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InventoryByawAstha.Web.Controllers.API
{
    [Authorize]
    [Route("api/product")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductApiController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        [Authorize(Policy = PermissionList.ProductView)]
        public async Task<IActionResult> GetAll()
        {
            var products = await productService.GetAll();
            var response = products.Select(p => new ProductGetAllResponseApiModel {
            ProductId=p.ProductId,
            Name=p.Name,
            Description=p.Description,
            ProductGroupName=p.ProductGroupName,
            ProductGroupId=p.ProductGroupId,
            UnitOfMeasureId=p.UnitOfMeasureId,
            UnitOfMeasureName=p.UnitofMeasureName,
            IsActive=p.IsActive,
            CreatedBy=p.CreatedBy,
            CreatedDate=p.CreatedDate,
            Quantity=p.Quantity
           
            });
            return Ok(response);    
           }       
           
        [HttpGet("{id:int}")]
        [Authorize(Policy = PermissionList.ProductView)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            
            var product = await productService.GetById(id);
            var response = new ProductGetResponseApiModel { 
            ProductId=product.ProductId,
            Name=product.Name,
            Description=product.Description,
            ProductGroupName=product.ProductGroupName,
            ProductGroupId=product.ProductGroupId,
            UnitOfMeasureId=product.UnitOfMeasureId,
            UnitOfMeasureName=product.UnitofMeasureName,
            IsActive=product.IsActive
            };
            return Ok(response);
        
        }
        [HttpPost]
        [Authorize(Policy = PermissionList.ProductCreate)]
        public async Task<IActionResult> Create([FromBody] ProductCreateRequestApiModel model)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) {
                return Unauthorized(new { message="User is not authenticated"});
            }
            int userId = int.Parse(userIdClaim.Value);
            var dto = new CreateProductDTO { 
            Name=model.Name,
            Description=model.Description,
            ProductGroupId=model.ProductGroupId,
            UnitofMeasureId=model.UnitOfMeasureId,
            IsActive=true
            };
            await productService.Create(dto,userId);
            return StatusCode(StatusCodes.Status201Created, 
                new { success=true,message="Product Created Successfully"});
        }
        [HttpPut("{id:int}")]
        [Authorize(Policy = PermissionList.ProductUpdate)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductUpdateRequestApiModel model) {
            var dto = new UpdateProductDTO { 
            ProductId=id,
            Name=model.Name,
            Description=model.Description,
            IsActive=model.IsActive,
            ProductGroupId=model.ProductGroupId,
            UnitofMeasureId=model.UnitOfMeasureId
            };
            await productService.Update(dto);
            return StatusCode(StatusCodes.Status200OK, new { message = "product updated successfully" });
            
            
        }
        [HttpGet("current-stocks")]
        [Authorize(Policy = PermissionList.ProductView)]
        public async Task<IActionResult> GetCurrentStocks() {
            var stocks = await productService.GetCurrentStocks();
            var response = stocks.Select(s => new CurrentStockGetResponseApiModel {
            ProductId=s.ProductId,
            Status=s.Status,
            ProductGroupName=s.ProductGroupName,
            ProductName=s.ProductName,
            Quantity=s.Quantity,
            UnitName=s.UnitName
            }).ToList();
            return Ok(response);
        }
    }
}
