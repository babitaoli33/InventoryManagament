using System.ComponentModel.DataAnnotations;

namespace InventoryByawAstha.Web.ApiModel.UserApiModel
{
    public class UserCreateRequestApiModel
    {
        [Required(ErrorMessage = "Please Enter Your Name")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter Your Email")]
        [EmailAddress(ErrorMessage = "Please Enter a Valid Email")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter Your Phone Number")]
        [StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "Please Enter a Valid Phone Number")]
        public string PhNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter a Password")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Select a Role")]
        public string Role { get; set; } = "User";

        public bool IsActive { get; set; } = true;
    }
}
