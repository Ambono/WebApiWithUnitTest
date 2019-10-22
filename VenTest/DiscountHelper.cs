using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VenTest
{
   
    public class DiscountHelper: IDiscount
    {
      
        public double AddDiscount(Item Item)
        {
            double totalprice = Item.Qty * Item.UnitPrice;

            if((Item.Qty == 2))
            {                
               totalprice = Item.UnitPrice;
            }
            if (Item.Code == "SO")
            {
                totalprice  = 0.75 * Item.Qty * Item.UnitPrice;
            }

            return totalprice;
        }
    }
}
