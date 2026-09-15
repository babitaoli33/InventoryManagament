namespace InventoryByawAstha.Web.ApiModel.VendorApiModel
{
    public class VendorUpdateRequestApiModel
    {
        public int VendorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
