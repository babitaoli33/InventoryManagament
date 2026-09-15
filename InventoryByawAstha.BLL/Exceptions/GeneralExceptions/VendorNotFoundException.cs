using InventoryByawAstha.BLL.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.GeneralExceptions
{
    public class VendorNotFoundException:NotFoundException
    {
        public VendorNotFoundException(int id) :
            base($"Unable to find the vendor with id: {id}", "VENDOR_NOT_FOUND")
        { }
    }
}
