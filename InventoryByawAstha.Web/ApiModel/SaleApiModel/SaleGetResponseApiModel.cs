namespace InventoryByawAstha.Web.ApiModel.SaleApiModel
{
    public class SaleGetResponseApiModel
    {
        public int SaleId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime SalesDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
