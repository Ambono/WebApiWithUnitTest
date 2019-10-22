using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VenTest
{
    
    public class Prices: IPrices
    {
        IItemCollection _itemcollect;
        IDiscount _discount ;
        public Prices(IItemCollection itemcollect, IDiscount discount) {
            _itemcollect = itemcollect;
            _discount = discount;
        }

       public  double CalculateTotalPrice(Item item)
        {
            _discount = new DiscountHelper();
            double total =  _discount.AddDiscount(item);
            
            return total;
        }

        public IList<Item> AddItem(int Id, string Code,
             double UnitPrice, int Qty, string Description)
        {            
            return _itemcollect.AddItem(Id, Code, UnitPrice, Qty, Description);
        }

    }
}
