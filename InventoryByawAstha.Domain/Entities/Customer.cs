using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public User User { get; set; } = null!;
        public int UserId { get; set; }
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();

    }
}


       


        


        



        


       



