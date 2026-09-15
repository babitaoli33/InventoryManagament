namespace InventoryByawAstha.Web.ApiModel.ProductApiModel
{
    public class ProductGetResponseApiModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ProductGroupName { get; set; } = string.Empty;
        public int ProductGroupId { get; set; }
        public int UnitOfMeasureId { get; set; }
        public string UnitOfMeasureName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = string.Empty;

        
    }
}
