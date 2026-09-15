using InventoryByawAstha.BLL.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.GeneralExceptions
{
    public class UserInactiveException:UnauthorizedException
    {
        public UserInactiveException() : base("User is InActive,Can't Login","INACTIVE_USER") { }
    }
}
