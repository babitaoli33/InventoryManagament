using InventoryByawAstha.BLL.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.GeneralExceptions
{
   public class LastAdminException:BusinessException
    {
        public LastAdminException() : base("Can't Deactivate the  Last Admin","LAST_ADMIN") { }
    }
}
