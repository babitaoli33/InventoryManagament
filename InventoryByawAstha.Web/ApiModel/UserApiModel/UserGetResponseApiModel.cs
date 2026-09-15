namespace InventoryByawAstha.Web.ApiModel.UserApiModel
{
    public class UserGetResponseApiModel
    {
        public int UserId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string PhNumber { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; }

    }
}
