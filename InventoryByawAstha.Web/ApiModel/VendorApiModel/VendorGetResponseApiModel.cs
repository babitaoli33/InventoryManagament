namespace InventoryByawAstha.Web.ApiModel.VendorApiModel
{
    public class VendorGetResponseApiModel
    {
        public int VendorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}
