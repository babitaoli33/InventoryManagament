namespace InventoryByawAstha.Web.ApiModel.PurchaseApiModel
{
    public class PurchaseGetResponseApiModel
    {
        public int PurchaseId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string CreatedBy { get; set; }
        public string VendorName { get; set; }
        public decimal TotalAmount { get; set; }
        public int VendorId { get; set; }
    }
 }   
        

        


