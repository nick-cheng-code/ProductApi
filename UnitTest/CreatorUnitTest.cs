using ProductCore.SaveData;
using ProductCore.Utilities;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Mock;

namespace UnitTest
{
    [TestClass]
    public class CreatorUnitTest
    {
        private readonly ICollections _collections;

        public CreatorUnitTest()
        {
            _collections = new Collections();
        }

        [DataTestMethod]
        [DataRow("Product 1", "My first product", 10.0, 1, 1)]
        public async Task Creator_Test(string name, string description, double price, int expectedId, int expectedNumberOfRecords)
        {
            IProductCreator creator = new ProductCreator(_collections);
            int id = await creator.Add(name, description, price);
            Assert.AreEqual(expectedId, id);
            Assert.AreEqual(expectedNumberOfRecords, _collections.Products.Count);

        }
        
    }
}
