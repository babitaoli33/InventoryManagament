using InventoryByawAstha.BLL.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;


namespace InventoryByawAstha.BLL.Exceptions.GeneralExceptions
{
    public class CustomerPhoneNumberExistsException : BusinessException 
    {
        public CustomerPhoneNumberExistsException(string phoneNumber) :
            base($"Customer with phone number:{phoneNumber} already exixsts", "PHONE_NUMBER_ALREADY_IN_USE")
        { }
    }
}
