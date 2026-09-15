using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.Interfaces
{
    public  interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
