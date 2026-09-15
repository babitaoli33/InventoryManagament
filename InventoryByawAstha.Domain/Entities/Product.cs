using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InventoryByawAstha.Domain.Entities.UnitofMeasure;

namespace InventoryByawAstha.Domain.Entities
{
    public class Product
    {
       
       public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int ProductGroupId { get; set; }
        public ProductGroup ProductGroup { get; set; } = null!;
        public int UnitOfMeasureId { get; set; }
        public UnitofMeasure UnitofMeasure { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public decimal SalesPrice { get; set; }
        public int Quantity { get; set; }
        public ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();
        public ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();

          }
}

       



      




       
       



        

       


       
 