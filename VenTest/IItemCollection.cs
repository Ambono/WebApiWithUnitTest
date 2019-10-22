using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VenTest
{
    public interface IItemCollection
    {
        IList<Item> AddItem(int Id, string Code,
             double UnitPrice, int Qty, string Description);

        //AddItem(int Id, string Code, double UnitPrice, int Qty, string Description)
    }
}
