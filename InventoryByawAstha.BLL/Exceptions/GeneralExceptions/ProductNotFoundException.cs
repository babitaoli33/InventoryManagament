using InventoryByawAstha.BLL.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.GeneralExceptions
{
public class ProductNotFoundException:NotFoundException
    {
        public ProductNotFoundException(int id):
            base($"Unable to find product with id:{id}","PRODUCT_NOT_FOUND")
        {
            
        }
    }
}
