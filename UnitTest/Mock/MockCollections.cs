using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Mock
{
    public class MockCollections : ICollections
    {
        public MockCollections() {

            Products = new List<IProduct>() {
                new Product()
                {
                    Id = 1,
                    Name = "Product 1",
                    Description = "My first product",
                    Price = 10.0
                },
                new Product()
                {
                    Id = 2,
                    Name = "Product 2",
                    Description = "My second product",
                    Price = 20.0
                },
                new Product()
                {
                    Id = 3,
                    Name = "Product 3",
                    Description = "My third product",
                    Price = 30.0
                },
                new Product()
                {
                    Id = 4,
                    Name = "Product 4",
                    Description = "My fourth product",
                    Price = 40.0
                },
                new Product()
                {
                    Id = 5,
                    Name = "Product 5",
                    Description = "My fifth product",
                    Price = 50.0
                },
            };
        
        }
        public IList<IProduct> Products { get; set; }

    }
}
