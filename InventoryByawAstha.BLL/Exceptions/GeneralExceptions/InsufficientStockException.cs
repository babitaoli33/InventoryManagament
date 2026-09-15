using InventoryByawAstha.BLL.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.GeneralExceptions
{
    public class InsufficientStockException:BusinessException
    {
        public InsufficientStockException(string productName) : base($"Insufficeint stock for{productName} ", "INSUFFICIENT_STOCK") { }
    }
}
