using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.RootException
{
    public class AppException:Exception
    {
        public int statusCode { get; }
        public string errorCode { get; }
        public AppException(string message, int statusCode, string errorCode) : base(message) {
            this.statusCode = statusCode;
            this.errorCode = errorCode;
        
        }
    }
}
