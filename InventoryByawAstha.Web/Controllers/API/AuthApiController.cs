using InventoryByawAstha.BLL.src.DTOs.AuthDTOs;
using InventoryByawAstha.BLL.src.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryByawAstha.Web.Controllers.API
{
    [AllowAnonymous]
    [Route("api/auth")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {

        private readonly IAuthService authService;


        public AuthApiController(IAuthService authService)
        {
            this.authService = authService;

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            var result = await authService.Login(dto);
            return Ok(result);


        }
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequestDTO dto) {
            var response = await authService.RefreshToken(dto.RefreshToken);
            return Ok(response);
        
        }
    }
}
    

                  

                        
                    
                
                
          
     
               
            
                   
           

            
              
               
           

            
                
                    
                

            
              
            
            
              
                    

            
            
               
                
            






