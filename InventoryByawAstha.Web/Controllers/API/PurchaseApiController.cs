using InventoryByawAstha.BLL.src.DTOs.PurchaseDTOs;
using InventoryByawAstha.BLL.src.Interfaces.Services;
using InventoryByawAstha.Web.Acl;
using InventoryByawAstha.Web.ApiModel.PurchaseApiModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InventoryByawAstha.Web.Controllers.API
{
    [Authorize]
    [Route("api/purchase")]
    [ApiController]
    public class PurchaseApiController : ControllerBase
    {
        private readonly IPurchaseService purchaseService;
        public PurchaseApiController(IPurchaseService purchaseService) {
            this.purchaseService = purchaseService;
        }
        [HttpGet]
        [Authorize(Policy = PermissionList.PurchaseView)]
        public async Task<IActionResult> GetAll() {
            var purchases = await purchaseService.GetAll();
            var response = purchases.Select(p => new PurchaseGetResponseApiModel { 
            PurchaseId=p.PurchaseId,
            PurchaseDate=p.PurchaseDate,
            CreatedBy=p.CreatedBy,
            VendorId=p.VendorId,
            VendorName=p.VendorName,
            TotalAmount=p.TotalAmount
            }).ToList();
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        [Authorize(Policy = PermissionList.PurchaseView)]
        public async Task<IActionResult> GetById([FromRoute] int id) {
            var purchaseDetails = await purchaseService.GetById(id);
            var response = purchaseDetails.Select(pd => new PurchaseDetailsGetResponseApiModel {
            PurchaseDetailId=pd.PurchaseDetailId,
            ProductId=pd.ProductId,
            ProductName=pd.ProductName,
            PurchasePrice=pd.PurchasePrice,
            SalesPrice=pd.SalesPrice,
            Quantity=pd.Quantity,
            Amount=pd.Amount
            }).ToList();

            return Ok(response);  
        }
        [HttpPost]
        [Authorize(Policy = PermissionList.PurchaseCreate)]
        public async Task<IActionResult> Create([FromBody] PurchaseCreateRequestApiModel model) {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) {
                return Unauthorized(new { message = "User not  authenticated" });
            }
            int userId = int.Parse(userIdClaim.Value);
            var dto = new CreatePurchaseDTO {
            VendorId=model.VendorId,
            Items=model.Items.Select(items=> new CreatePurchaseDetailsDTO { 
            ProductId=items.ProductId,
            Quantity=items.Quantity,
            PurchasePrice=items.PurchasePrice,
            SalesPrice=items.SalesPrice
            }).ToList()};
            await purchaseService.Create(dto, userId);
            return StatusCode(StatusCodes.Status201Created, new { message = "Purchase created successfully" });
        }
        
        
        
        
        
        
    }
}
