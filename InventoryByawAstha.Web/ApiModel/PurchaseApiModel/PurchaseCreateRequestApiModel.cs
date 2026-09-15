namespace InventoryByawAstha.Web.ApiModel.PurchaseApiModel
{
    public class PurchaseCreateRequestApiModel
    {
        public int VendorId { get; set; }
        public List<PurchaseItemCreateRequestApiModel> Items { get; set; } = new();
           
    }
}
