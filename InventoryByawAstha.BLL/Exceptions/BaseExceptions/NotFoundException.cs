using InventoryByawAstha.BLL.Exceptions.RootException;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.BaseExceptions
{
    public class NotFoundException:AppException
    {
        public NotFoundException(string message, string errorCode) :
            base(message, StatusCodes.Status404NotFound, "NOT_FOUND")
        { }
    }
}
