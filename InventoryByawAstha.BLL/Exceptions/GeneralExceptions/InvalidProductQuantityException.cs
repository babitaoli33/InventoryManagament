using InventoryByawAstha.BLL.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.GeneralExceptions
{
    public class InvalidProductQuantityException:BusinessException
    {
        public InvalidProductQuantityException() : base("Invalid Product Quantity", "INVALID_PRODUCT_QUANTITY") { }
    }
}
