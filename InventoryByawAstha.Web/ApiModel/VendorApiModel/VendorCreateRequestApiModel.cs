namespace InventoryByawAstha.Web.ApiModel.VendorApiModel
{
    public class VendorCreateRequestApiModel
    {
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public string Description { get; set; } = string.Empty;
    }
}
