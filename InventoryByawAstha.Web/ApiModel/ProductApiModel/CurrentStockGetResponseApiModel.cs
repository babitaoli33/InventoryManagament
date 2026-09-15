namespace InventoryByawAstha.Web.ApiModel.ProductApiModel
{
    public class CurrentStockGetResponseApiModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductGroupName { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public string Status { get; set; } = string.Empty;
        
        

       
       
    }
}
