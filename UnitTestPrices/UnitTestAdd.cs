using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VenTest;
using Xunit.Sdk;
using VenTest = VenTest;
namespace UnitTestPrices
{
    [TestClass]
    public class UnitTest2
    {
        IItemCollection _itemcollect;
        IDiscount _discount;
        [TestMethod]
        public void TestMethodAdd()
        {
            //  arrange
           
            Prices ven = new Prices(_itemcollect, _discount);

            //  act
            Item myItem = new Item(3, "BK", 10, 4, "Book");
            IList<Item> actualnewlist = new List<Item>();
            actualnewlist.Add(myItem);
            IList<Item> expectednewlist = ven.AddItem(3, "BK", 10, 4, "Book");

            //assert

            Assert.AreEqual(expectednewlist, actualnewlist);
        }
        
    }
}
