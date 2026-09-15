using InventoryByawAstha.BLL.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.GeneralExceptions
{
    public class CodeNameAlreadyInUseException:BusinessException
    {
        public CodeNameAlreadyInUseException(string code):base($"{code}already in use", "CODE_FOR_THE_UNIT_ALREADY_IN_USE") { }
    }
}
