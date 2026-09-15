using System.ComponentModel.DataAnnotations;

namespace InventoryByawAstha.Web.ApiModel.CustomerApiModel
{
    public class CustomerCreateRequestApiModel
    {
        public string Name { get; set; } = string.Empty;
        [StringLength(maximumLength:10,MinimumLength =10,ErrorMessage ="Please enter a valid phone number")]
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
