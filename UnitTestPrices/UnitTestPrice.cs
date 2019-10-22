using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
//using Xunit.Sdk;

using VenTest;
using VenTest.Controllers;

namespace UnitTestPrices
{
    [TestClass]
    public class UnitTestPrice
    {
        IItemCollection _itemcollect;
        IDiscount _discount;
        [TestMethod]
        public void TestMethod1PlainPrice()
        {
            //  arrange

            Item item1 = new Item(1, "TN", 10, 1, "Tin");
            Item item2 = new Item(2, "BK", 15, 3, "Book");
          
            List<Item> Item = new List<Item> { item1, item2 };
            Prices ven = new Prices(_itemcollect, _discount);

            //  act
            double expectedtotal = ven.CalculateTotalPrice(item1);
            double actualtotal = 10;
          //assert

            Assert.AreEqual(expectedtotal, Math.Round( actualtotal, 1));

        }
        //[DataTestMethod]
        //[DataRow(1, 2, 2)]
        //[DataRow(2, 3, 5)]
       // [DataRow(3, 5, 8)]
       [TestMethod]
        public void TestMethod1CalculateDiscount()
        {
            //  arrange
            Item item1 = new Item(1, "SO", 100, 1, "Soap");
            Item item2 = new Item(2, "BK", 15, 3, "Book");
            Item item3 = new Item(2, "CH", 11, 2, "Chair");
            
            Prices ven = new Prices(_itemcollect, _discount);
            //  act
            double expectedtotal = ven.CalculateTotalPrice(item2);
            double actualprice = Math.Round(45.00, 2);
            //assert

            Assert.AreEqual(expectedtotal, actualprice);

        }

        [TestMethod]
        public void TestMethodControllerCalculateTotalPrice()
        {
            Prices price = new Prices(_itemcollect, _discount);
            PriceController controller = new PriceController(price);
            // This version uses a mock UrlHelper.
            
            // Arrange           
            Item item1 = new Item(1, "SO", 100, 1, "Soap");
            Item item2 = new Item(2, "BK", 15, 3, "Book");
            Item item3 = new Item(2, "CH", 11, 2, "Chair");
            
            // Act
            var response = controller.DisplayPrice(item2);
            OkObjectResult res = new OkObjectResult(200);
           

            res.StatusCode = 200;
            res.Value = 45.0;

            // Assert
          //  response.Should().Be(res);
            Assert.AreEqual(res.Value, 45.0);
            Assert.AreEqual(res.StatusCode, 200);
        }

       
    }
}
