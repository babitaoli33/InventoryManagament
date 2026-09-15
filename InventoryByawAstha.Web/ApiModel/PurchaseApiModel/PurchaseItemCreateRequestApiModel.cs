namespace InventoryByawAstha.Web.ApiModel.PurchaseApiModel
{
    public class PurchaseItemCreateRequestApiModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalesPrice { get; set; }
     }
}
    

        
