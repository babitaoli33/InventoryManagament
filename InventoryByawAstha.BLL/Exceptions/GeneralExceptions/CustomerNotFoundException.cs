using InventoryByawAstha.BLL.Exceptions.BaseExceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.GeneralExceptions
{
    public class CustomerNotFoundException:NotFoundException
    {
        public CustomerNotFoundException(int id)
            :base($"Unable to find customer with id:{id}","CUSTOMER_NOT_FOUND") { }
    }
}
