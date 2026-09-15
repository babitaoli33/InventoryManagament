using InventoryByawAstha.BLL.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.GeneralExceptions
{
    public class InvalidCredentialsException : UnauthorizedException {
        public InvalidCredentialsException() : base("Invalid Credentials","INVALID_USERNAME_OR_PASSWORD") { }
    
    }
   
    }

