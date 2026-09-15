namespace InventoryByawAstha.Web.ApiModel.CustomerApiModel
{
    public class CustomerGetResponseApiModel
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public bool IsActive { get; set; }

    }
}
