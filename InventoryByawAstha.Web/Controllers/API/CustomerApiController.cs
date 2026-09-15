using InventoryByawAstha.BLL.src.DTOs.CustomerDTOs;
using InventoryByawAstha.BLL.src.Interfaces.Services;
using InventoryByawAstha.Web.Acl;
using InventoryByawAstha.Web.ApiModel.CustomerApiModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InventoryByawAstha.Web.Controllers.API
{
    [Authorize]
    [Route("api/customer")]
    [ApiController]
    public class CustomerApiController : ControllerBase
    {
        private readonly ICustomerService customerService;
        public CustomerApiController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        [Authorize(Policy = PermissionList.CustomerView)]
        public async Task<IActionResult> GetAll()
        {
            var customers = await customerService.GetAll();
            var response = customers.Select(c => new CustomerGetResponseApiModel
            {
                CustomerId = c.CustomerId,
                Name = c.Name,
                Address = c.Address,
                IsActive = c.IsActive,
                Phone = c.Phone,
                CreatedBy = c.CreatedBy,
            }).ToList();
            return Ok(response);
        }
        [HttpGet("{id:int}")]

        [Authorize(Policy = PermissionList.CustomerView)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var customer = await customerService.GetById(id);
            var response = new CustomerGetResponseApiModel
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Address = customer.Address,
                Phone = customer.Phone,
                IsActive = customer.IsActive,
                CreatedBy = customer.CreatedBy
            };
            return Ok(response);
        }
        [HttpPost]
        [Authorize(Policy = PermissionList.CustomerCreate)]
        public async Task<IActionResult> Create([FromBody] CustomerCreateRequestApiModel model)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) { return Unauthorized(new { message = "User Not Authenticated" }); }
            int UserId = int.Parse(userIdClaim.Value);
            var dto = new CreateCustomerDTO
            {
                Name = model.Name,
                Address = model.Address,
                Phone = model.Phone,
                IsActive = model.IsActive
            };
            await customerService.Create(dto, UserId);
            return StatusCode(StatusCodes.Status201Created, new { message = "Created Customer Successfully" });


        }
        [HttpPut("{id:int}")]
        [Authorize(Policy = PermissionList.CustomerUpdate)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CustomerUpdateRequestApiModel model)
        {
            var dto = new UpdateCustomerDTO
            {
                CustomerId = id,
                Name = model.Name,
                Phone = model.Phone,
                Address = model.Address,
                IsActive = model.IsActive
            };
            await customerService.Update(dto);
            return Ok(new { message = "Customer Updated Successfully" });

        }
    }
}
