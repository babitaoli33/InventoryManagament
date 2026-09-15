using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.DTOs.AuthDTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Please Enter Your Email")]
        [EmailAddress(ErrorMessage = "Enter a Valid Email")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter Your Password")]
        public string Password { get; set; } = string.Empty;
    }
}
