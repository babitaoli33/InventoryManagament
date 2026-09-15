using InventoryByawAstha.BLL.src.DTOs.ProductDTOs;
using InventoryByawAstha.BLL.src.DTOs.VendorDTOs;
using InventoryByawAstha.BLL.src.Interfaces.Services;
using InventoryByawAstha.Web.ApiModel.VendorApiModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InventoryByawAstha.Web.Controllers.API
{
    [Authorize]
    [Route("api/vendors")]
    [ApiController]
    public class VendorApiController : ControllerBase
    {
        private readonly IVendorService vendorService;
        public VendorApiController(IVendorService vendorService)
        {
            this.vendorService = vendorService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vendors = await vendorService.GetAll();
            var response = vendors.Select(v => new VendorGetResponseApiModel
            {
                VendorId = v.VendorId,
                Name = v.Name,
                Description = v.Description,
                IsActive = v.IsActive,
                CreatedBy = v.CreatedBy
            }).ToList();
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var vendor = await vendorService.GetById(id);
            var response = new VendorGetResponseApiModel
            {
                VendorId = vendor.VendorId,
                Name = vendor.Name,
                Description = vendor.Description,
                IsActive = vendor.IsActive,
                CreatedBy = vendor.CreatedBy
            };
            return Ok(response);

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VendorCreateRequestApiModel model)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) { return Unauthorized(new { message = "User not authenticated" }); }
            int UserId = int.Parse(userIdClaim.Value);
            var dto = new CreateVendorDTO
            {
                Description = model.Description,
                Name = model.Name,
                IsActive = model.IsActive
            };
            await vendorService.Create(dto, UserId);
            return StatusCode(StatusCodes.Status201Created, new { message = " new Vendor created successfully" });
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] VendorUpdateRequestApiModel model)
        {
            var dto = new UpdateVendorDTO
            {
                VendorId = id,
                Name = model.Name,
                Description = model.Description,
                IsActive = model.IsActive
            };
            await vendorService.Update(dto);
            return Ok(new { message = "Vendor updated successfully" });

        }










    }
}
