using InventoryByawAstha.BLL.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.GeneralExceptions
{
    public class InvalidPriceException:BusinessException
    {
        public InvalidPriceException() : base("Not a Valid Price","INVALID_PRICE") { }

    }
}
