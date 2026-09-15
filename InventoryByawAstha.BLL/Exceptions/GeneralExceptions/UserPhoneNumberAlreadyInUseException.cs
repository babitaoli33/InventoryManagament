using InventoryByawAstha.BLL.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.GeneralExceptions
{
    public class UserPhoneNumberAlreadyInUseException:BusinessException
    {
        public UserPhoneNumberAlreadyInUseException() : base("Phone Number Already In Use", "PHONE_NUMBER_ALREADY_IN_USE") { }
    }
}
