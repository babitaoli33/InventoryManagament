using InventoryByawAstha.BLL.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.Exceptions.GeneralExceptions
{
    public class UnitofMeasureNotFoundException : NotFoundException {
        public UnitofMeasureNotFoundException(int id):
            base($"Unable to find unit  with id: {id}","UNIT_OF_MEASURE_NOT_FOUND"){ 
        
        }
    
    
    }
}
