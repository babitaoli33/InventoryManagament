using InventoryByawAstha.BLL.Exceptions.GeneralExceptions;
using InventoryByawAstha.BLL.src.DTOs.UnitofMeasureDTOs;
using InventoryByawAstha.BLL.src.Interfaces.Services;
using InventoryByawAstha.Web.Acl;
using InventoryByawAstha.Web.ApiModel.UnitOfMeasureApiModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace InventoryByawAstha.Web.Controllers.API
{
    [Authorize]
    [Route("api/unitofmeasure")]
    [ApiController]
    public class UnitOfMeasureApiController : ControllerBase
    {
        private readonly IUnitOfMeasureService unitOfMeasureService;
        public UnitOfMeasureApiController(IUnitOfMeasureService unitOfMeasureService)
        {
            this.unitOfMeasureService = unitOfMeasureService;
        }


        [HttpGet]
        [Authorize(Policy = PermissionList.UnitOfMeasureView)]
        public async Task<IActionResult> GetAll() {
            
            var units = await unitOfMeasureService.GetAll();
            var response = units.Select(uom => new UnitOfMeasureGetResponseApiModel { 
            UnitOfMeasureId=uom.UnitOfMeasureId,
            Name=uom.Name,
            Description=uom.Description,
            IsActive=uom.IsActive,
            Code=uom.Code,
          }).ToList();
            
             return Ok(response);
           }      
            
        
        [HttpGet("{id:int}")]
        [Authorize(Policy = PermissionList.UnitOfMeasureView)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var unit = await unitOfMeasureService.GetById(id);
            var response = new UnitOfMeasureGetResponseApiModel { 
            UnitOfMeasureId=unit.UnitOfMeasureId,
            Name=unit.Name,
            Description=unit.Description,
            Code=unit.Code,
            IsActive=unit.IsActive
            };
            return Ok(response);     

        }

        [HttpPost]
        [Authorize(Policy = PermissionList.UnitOfMeasureCreate)]
        public async Task<IActionResult> Create([FromBody] UnitOfMeasureCreateRequestApiModel model)
        {
            var dto = new CreateUomDTO { 
            Name=model.Name,
            Description=model.Description,
            Code=model.Code,
            IsActive=model.IsActive
            };
            await unitOfMeasureService.Create(dto);
            return StatusCode(StatusCodes.Status201Created, new { message = "new Unit Created successfully" });
           }
           
        [HttpPut("{id:int}")]
        [Authorize(Policy = PermissionList.UnitOfMeasureUpdate)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UnitOfMeasureUpdateRequestApiModel model) {
            var dto = new UpdateUomDTO { 
            UnitOfMeasureId=id,
            Name=model.Name,
            Description=model.Description,
            IsActive=model.IsActive,
            Code=model.Code};
            await unitOfMeasureService.Update(dto);
            return Ok(new { message = "unit updated successfully" });
            
          }  
      
    }
}      

            
   
           

        
     
