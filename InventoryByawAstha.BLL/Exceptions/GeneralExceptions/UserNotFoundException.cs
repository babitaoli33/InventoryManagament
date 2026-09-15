using InventoryByawAstha.BLL.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.GeneralExceptions
{
    public class UserNotFoundException:NotFoundException
    {
        public UserNotFoundException(int id) : 
            base($"Unable to find User with id: {id}","USER_NOT_FOUND") { }
    }
}
