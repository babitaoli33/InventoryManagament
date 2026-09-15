namespace InventoryByawAstha.Web.ApiModel.PurchaseApiModel
{
    public class PurchaseDetailsGetResponseApiModel
    {
        public int PurchaseDetailId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalesPrice { get; set; }
       public decimal Amount { get; set; }
     }    
        
}   
        
       
      
       

