using InventoryByawAstha.BLL.src.DTOs.UserDTOs;
using InventoryByawAstha.BLL.src.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryByawAstha.Web.Controllers.MVC
{
    
    public class UserController : Controller
    {
        private readonly IUserService userService;
        public UserController (IUserService userService) {
            this.userService = userService;
        }
        public async  Task<IActionResult> Index()
        {
            var users = await userService.GetAllUsers();
            return View(users);
        }
      
        [HttpGet]
        public async Task<IActionResult> CreateUser() {
            return View();        
          }
      
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDTO dtoUser) {
            if (ModelState.IsValid) {
                await userService.CreateUser(dtoUser);
                return RedirectToAction("Index", "User");
            }
            return View(dtoUser);
        }
        
        [HttpGet]
        public async Task<IActionResult> UpdateUser(int id) {
            var user = await userService.GetUserForUpdate(id);
            return View(user);
      }
      
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserDTO dtoUser) {
            if (ModelState.IsValid) {
                await userService.UpdateUser(dtoUser);
                return RedirectToAction("Index", "User");
            }
            return View(dtoUser);
        }
 
      
    }
}
