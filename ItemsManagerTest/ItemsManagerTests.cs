using System.Collections.Generic;
using FirstRESTController.Managers;
using FirstRESTController.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ItemsManagerTest
{
    [TestClass]
    public class ItemsManagerTests
    {
        [TestMethod]
        public void GetAllTest()
        {
            IItemsManager manager = new ItemsManager();

            int itemCount = manager.GetAll("").Count;

            Assert.AreEqual(2, itemCount);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            IItemsManager manager = new ItemsManager();
            Item item = new Item {Itemquality = 5, Name = "Id 3", Quantity = 7};

            manager.Add(item);

            Item TestItem = manager.GetById(3);

            Assert.AreEqual(item, TestItem);
        }
    }
}
