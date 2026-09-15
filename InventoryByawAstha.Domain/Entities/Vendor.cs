using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.Domain.Entities
{
    public class Vendor
    {
        public int VendorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    }
}

       



       


       



       
