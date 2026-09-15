using InventoryByawAstha.BLL.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.GeneralExceptions
{
    public class VendorAlreadyExistsException:BusinessException
    {
        public VendorAlreadyExistsException(string name) : base("Vendor already exists", "VENDOR_EXISTS_ALREADY") { }
    }
}
