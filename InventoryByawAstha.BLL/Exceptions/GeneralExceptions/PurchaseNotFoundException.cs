using InventoryByawAstha.BLL.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.GeneralExceptions
{
     public  class PurchaseNotFoundException:NotFoundException
    {
        public PurchaseNotFoundException(int id) :
            base($"Unable to find Purchase with id:{id}", "PURCHASE_NOT_FOUND")
        { }
    }
}
