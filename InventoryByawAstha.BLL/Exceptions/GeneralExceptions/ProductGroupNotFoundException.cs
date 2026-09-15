using InventoryByawAstha.BLL.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.GeneralExceptions
{
    public class ProductGroupNotFoundException:NotFoundException
    {
        public ProductGroupNotFoundException(int id)
            : base($"Unable to find Product Group with id:{id}","PRODUCT_GROUP_NOT_FOUND")
        {
          
        }
      
    }
}
