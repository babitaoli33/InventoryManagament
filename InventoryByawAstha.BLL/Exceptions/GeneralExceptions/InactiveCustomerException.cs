using InventoryByawAstha.BLL.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.GeneralExceptions
{
    public class InactiveCustomerException:UnauthorizedException
    {
        public InactiveCustomerException() : 
            base("Can't create a sale for an inactive customer","INACTIVE_CUSTOMER") { }
    }
}
