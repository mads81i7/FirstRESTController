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
            manager.DeleteAll();

            Item item1 = new Item("item", 1, 1);
            Item item2 = new Item("item", 1, 1);

            manager.Add(item1);
            manager.Add(item2);

            int itemCount = manager.GetAll("").Count;

            Assert.AreEqual(2, itemCount);
        }

        [TestMethod]
        public void FailThis()
        {
            Assert.Fail();
        }
    }
}
