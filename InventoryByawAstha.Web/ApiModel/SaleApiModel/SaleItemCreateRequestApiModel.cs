namespace InventoryByawAstha.Web.ApiModel.SaleApiModel
{
    public class SaleItemCreateRequestApiModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal SalesPrice { get; set; }
    }
}
