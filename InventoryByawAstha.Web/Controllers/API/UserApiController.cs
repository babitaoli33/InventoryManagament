using InventoryByawAstha.BLL.Exceptions.GeneralExceptions;
using InventoryByawAstha.BLL.src.DTOs.UserDTOs;
using InventoryByawAstha.BLL.src.Interfaces.Services;
using InventoryByawAstha.Web.Acl;
using InventoryByawAstha.Web.ApiModel.UserApiModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace InventoryByawAstha.Web.Controllers.API
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IUserService userService;
        public UserApiController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]

        [Authorize(Policy = PermissionList.UserView)]
        public async Task<IActionResult> GetUsers()
        {
            var users = await userService.GetAllUsers();
            var response = users.Select(u => new UserGetResponseApiModel
            {
                UserId = u.UserId,
                Name = u.Name,
                Email = u.Email,
                PhNumber = u.PhNumber,
                Role = u.Role,
                IsActive = u.IsActive
            }).ToList();
            return Ok(response);

        }

        [HttpGet("{id:int}")]
        [Authorize(Policy = PermissionList.UserView)]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var user = await userService.GetUserById(id);
            var response = new UserGetResponseApiModel
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                PhNumber = user.PhNumber,
                Role = user.Role,
                IsActive = user.IsActive
            };
            return Ok(user);
        }


        [HttpPost]
        [Authorize(Policy = PermissionList.UserCreate)]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateRequestApiModel model)
        {
            var dto = new CreateUserDTO
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                Role = model.Role,
                PhNumber = model.PhNumber,
                IsActive = model.IsActive,

            };
            await userService.CreateUser(dto);
            return StatusCode(StatusCodes.Status201Created,
                new { sucess = true, message = "User Created Successfully" });

        }
        [HttpPut("{id:int}")]
        [Authorize(Policy = PermissionList.UserUpdate)]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UserUpdateRequestApiModel model)
        {
            var dto = new UpdateUserDTO
            {
                UserId = id,
                Name = model.Name,
                Email = model.Email,
                PhNumber = model.PhNumber,
                Role = model.Role,
                IsActive = model.IsActive
            };
            await userService.UpdateUser(dto);
            return Ok(new { message = "User updated successfully" });

        }

        [HttpPut("deactivate/{id:int}")]
        [Authorize(Policy = PermissionList.UserDeactivate)]
        public async Task<IActionResult> DeactivateUser([FromRoute] int id)
        {
            await userService.DeactivateUser(id);
            return Ok(new { messgae = "user deactivated successfully" });


        }
        [HttpPut("activate/{id:int}")]
        [Authorize(Policy = PermissionList.UserActivate)]
        public async Task<IActionResult> ActivateUser([FromRoute] int id)
        {

            await userService.ActivateUser(id);
            return Ok(new { message = "User activated successfully" });
        }


    }




}

