using InventoryByawAstha.BLL.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.GeneralExceptions
{
    public class UnitAlreadyExistsException:BusinessException
    {
        public UnitAlreadyExistsException(string name) : base($"{name} already exists", "UNIT_ALREADY_EXISTS") { }
    }
}
