namespace InventoryByawAstha.Web.ApiModel.ProductGroupApiModel
{
    public class ProductGroupGetResponseApiModel
    {
        public int ProductGroupId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}
