using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VenTest
{
    public class Item
    {
       // public Item() { }
        public Item(int id,
            string code,
           double  unitPrice,
           int qty,
        string description)
        {
            Id = id;
            Code = code;
            UnitPrice = unitPrice;
            Qty = qty;
            Description = description;
        }
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public string Description { get; set; }       
    }

    public class ItemCollection : IItemCollection
    {
        public Item item { get; set; }
        IList<Item> itemsLst = new List<Item>();
        public IList<Item> AddItem( int Id, string Code,
             double UnitPrice, int Qty, string Description)
        {
            Item myitem = new Item(Id, Code, UnitPrice, Qty, Description);
            itemsLst.Add(myitem);
            return itemsLst;
        }
    }

    



}
