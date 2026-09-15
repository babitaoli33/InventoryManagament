using InventoryByawAstha.BLL.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.GeneralExceptions
{
    public class ProductGroupExistsException:BusinessException
    {
        public ProductGroupExistsException(string groupName) : base($"Product Group with name: {groupName} already exists", "PRODUCT_GROUP_ALREADY_EXISTS") { }
    }
}
