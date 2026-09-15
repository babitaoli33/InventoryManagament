namespace InventoryByawAstha.Web.ApiModel.SaleApiModel
{
    public class SaleCreateRequestApiModel
    {
        public int CustomerId { get; set; }
        public List<SaleItemCreateRequestApiModel> Items { get; set; } = new List<SaleItemCreateRequestApiModel>();
    }
}
