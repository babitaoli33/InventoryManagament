using InventoryByawAstha.BLL.Exceptions.RootException;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.BaseExceptions
{
    public class UnauthorizedException:AppException
    {
        public UnauthorizedException(string message, string errorCode = "UNAUTHORIZED") :
            base( message,StatusCodes.Status401Unauthorized, errorCode)
        { 
        }
    }
}
