
using InventoryByawAstha.BLL.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.GeneralExceptions
{
    public class InvalidPurchaseException:BusinessException
    {
        public InvalidPurchaseException() : base("Unable to make purchase", "INVALID_PURCHASE") { }
    }
}
