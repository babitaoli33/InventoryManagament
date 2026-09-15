using InventoryByawAstha.BLL.src.DTOs.SalesDTOs;
using InventoryByawAstha.BLL.src.Interfaces.Services;
using InventoryByawAstha.Domain.Entities;
using InventoryByawAstha.Web.Acl;
using InventoryByawAstha.Web.ApiModel.SaleApiModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InventoryByawAstha.Web.Controllers.API
{
    [Authorize]
    [Route("api/sale")]
    [ApiController]
    public class SalesApiController : ControllerBase
    {
        private readonly ISaleService saleService;
        public SalesApiController(ISaleService saleService) {
            this.saleService = saleService;
        }
        [HttpGet]
        [Authorize(Policy = PermissionList.SaleView)]
        public async Task<IActionResult> GetAll() {
            var sales = await saleService.GetAll();
            var response = sales.Select(s => new SaleGetResponseApiModel {
            SaleId=s.SaleId,
            SalesDate=s.SalesDate,
            CustomerId=s.CustomerId,
            CustomerName=s.CustomerName,
            CreatedBy=s.CreatedBy,
            TotalAmount=s.TotalAmount
            }).ToList(); 
            return Ok(response);
        }
        
        [HttpGet("{id:int}")]
        [Authorize(Policy = PermissionList.SaleView)]
        public async Task<IActionResult> GetById([FromRoute] int id) {
            var sale = await saleService.GetById(id);
            var response = new {
                saleId = sale.SaleId,
                customerId = sale.CustomerId,
                salesDate = sale.SalesDate,
                customerName = sale.CustomerName,
                createdBy = sale.CreatedBy,
                totalAmount = sale.TotalAmount,
                items = sale.SaleDetails.Select(sd => new SaleDetailsGetResponseApiModel {
                SaleDetailId=sd.SaleDetailId,
                SalesPrice=sd.SalesPrice,
                Amount=sd.Amount,
                ProductId=sd.ProductId,
                ProductName=sd.ProductName,
                Quantity=sd.Quantity
                }).ToList()
                };

            return Ok(response);
          }


        [HttpPost]
        [Authorize(Policy = PermissionList.SaleCreate)]
        public async Task<IActionResult> Create([FromBody] SaleCreateRequestApiModel model) {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) { return Unauthorized(new { message = "User not authenticated" }); }
            int userId = int.Parse(userIdClaim.Value);
            var dto = new CreateSalesDTO {
            CustomerId=model.CustomerId,
            Items=model.Items.Select(item=> new CreateSaleDetailsDTO { 
            ProductId= item.ProductId,
            Quantity=item.Quantity,
            SalesPrice=item.SalesPrice
           }).ToList()
          };
            await saleService.Create(dto, userId);
            return StatusCode(StatusCodes.Status201Created, new { message = "sale created successfully" });
            
        }            
    }
}
