namespace InventoryByawAstha.Web.ApiModel.SaleApiModel
{
    public class SaleDetailsGetResponseApiModel
    {
        public int SaleDetailId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal Amount { get; set; }

       }
}
    

        
        
 