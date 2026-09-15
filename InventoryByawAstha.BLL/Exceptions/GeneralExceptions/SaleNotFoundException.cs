using InventoryByawAstha.BLL.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.GeneralExceptions
{
    public class SaleNotFoundException:NotFoundException
    {
        public SaleNotFoundException(int id) : base($"Unable to find sale with id: {id}", "SALE_NOT_FOUND") { }
    }
}
