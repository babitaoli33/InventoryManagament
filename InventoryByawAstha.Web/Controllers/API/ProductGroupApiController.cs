using InventoryByawAstha.BLL.Exceptions.GeneralExceptions;
using InventoryByawAstha.BLL.src.DTOs.ProductGroupDTOs;
using InventoryByawAstha.BLL.src.Interfaces.Services;
using InventoryByawAstha.Web.Acl;
using InventoryByawAstha.Web.ApiModel.ProductGroupApiModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace InventoryByawAstha.Web.Controllers.API
{
    [Authorize]
    [Route("api/product-groups")]
    [ApiController]
    public class ProductGroupApiController : ControllerBase
    {
        private readonly IProductGroupService productGroupService;
        public ProductGroupApiController(IProductGroupService productGroupService) {
            this.productGroupService = productGroupService;
        }
      
        [HttpGet]
        [Authorize(Policy = PermissionList.ProductGroupView)]
        public async Task<IActionResult> GetAllProductGroups()
        {
            var productGroups = await productGroupService.GetAll();
            var response=productGroups.Select(pg => new ProductGroupGetResponseApiModel { 
            ProductGroupId=pg.ProductGroupId,
            Description=pg.Description,
            CreatedBy=pg.CreatedBy,
            IsActive=pg.IsActive,
            Name=pg.Name
            }).ToList();
            return Ok(response);
         }

        
        [HttpGet("{id:int}")]
        [Authorize(Policy = PermissionList.ProductGroupView)]
        public async Task<IActionResult> ViewProductGroup([FromRoute] int id) {
             var productGroup = await productGroupService.GetById(id);
            var response = new ProductGroupGetResponseApiModel { 
            ProductGroupId=productGroup.ProductGroupId,
            Name=productGroup.Name,
            Description=productGroup.Description,
            CreatedBy=productGroup.CreatedBy,
            IsActive=productGroup.IsActive
            };
            
                return Ok(response);

        }
        [HttpPost]
        [Authorize(Policy = PermissionList.ProductGroupCreate)]
        public async Task<IActionResult> CreateProductGroup([FromBody] ProductGroupCreateRequestApiModel model) 
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) { return Unauthorized(new { message = "Unauthenticated User" }); }
            int userId = int.Parse(userIdClaim.Value);
            var dto = new CreateProductGroupDTO { 
            Name= model.Name,
            Description=model.Description,
            IsActive=model.IsActive,
           };
            await productGroupService.Create(dto, userId);
            return StatusCode(StatusCodes.Status201Created, 
                new {success=true, message = "new Product group created successfully" });
         }   

        
        [HttpPut("{id:int}")]
        [Authorize(Policy = PermissionList.ProductGroupUpdate)]
        public async Task<IActionResult> UpdateProductGroup([FromRoute] int id, [FromBody] ProductGroupUpdateRequestApiModel model)
        {
            var dto = new UpdateProductGroupDTO { 
            ProductGroupId=id,
            Name=model.Name,
            Description=model.Description,
            IsActive=model.IsActive
            };
            await productGroupService.Update(dto);
            return Ok(new { message = "Product Group updated Successfully" });
        }    
        
        
        
    }
}
