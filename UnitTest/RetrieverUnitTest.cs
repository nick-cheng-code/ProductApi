using ProductCore;
using ProductCore.GetData;
using Store.Models;
using UnitTest.Mock;

namespace UnitTest
{
    [TestClass]
    public class RetrieverUnitTest
    {
        private readonly ICollections _collections;
        
        public RetrieverUnitTest()
        {
            _collections = new MockCollections();
            
        }

        [DataTestMethod]
        [DataRow(1, 1, "Product 1", "My first product", 10.0)]
        [DataRow(2, 2, "Product 2", "My second product", 20.0)]
        [DataRow(3, 3, "Product 3", "My third product", 30.0)]
        [DataRow(4, 4, "Product 4", "My fourth product", 40.0)]
        [DataRow(5, 5, "Product 5", "My fifth product", 50.0)]
        public async Task RetrieveDataById_Test(int id, int expectedId, string expectedName, string expectedDescription, double expectedPrice)
        {
            IProductRetriever _retriever = new ProductRetriever(_collections);
            IProduct product = await _retriever.Get(id);

            Assert.IsNotNull(product);
            Assert.AreEqual(expectedId, product.Id);
            Assert.AreEqual(expectedName,  product.Name);
            Assert.AreEqual(expectedDescription, product.Description);
            Assert.AreEqual(expectedPrice, product.Price);
        }

        [DataTestMethod]
        [DataRow("Product 1", 1)]
        [DataRow("Product", 5)]
        [DataRow("Prod", 5)]
        [DataRow("ABC",0)]
        public async Task RetrieveDataByName_Test(string name, int expectedNumberOfRecords)
        {
            IProductRetriever _retriever = new ProductRetriever(_collections);
            IList<IProduct> products = await _retriever.GetByName(name);

            Assert.AreEqual(expectedNumberOfRecords, products.Count);

        }
    }
}