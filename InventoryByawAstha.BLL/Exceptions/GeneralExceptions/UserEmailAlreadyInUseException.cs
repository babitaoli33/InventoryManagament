using InventoryByawAstha.BLL.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.GeneralExceptions
{
    public class UserEmailAlreadyInUseException : BusinessException 
    {
        public UserEmailAlreadyInUseException() : base("Email already in use", "EMAIL_ALREADY_IN_USE") { }
    }
}
