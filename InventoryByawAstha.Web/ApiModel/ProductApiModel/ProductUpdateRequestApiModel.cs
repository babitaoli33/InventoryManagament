namespace InventoryByawAstha.Web.ApiModel.ProductApiModel
{
    public class ProductUpdateRequestApiModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ProductGroupId { get; set; }
        public int UnitOfMeasureId { get; set; }
        public bool IsActive { get; set; }
      
         
    }
}
