using ProductCore.Utilities;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCore.SaveData
{
    public class ProductCreator : IProductCreator
    {

        private readonly ICollections _collections;

        public ProductCreator(ICollections collections) {
            _collections = collections;

            InitialProductList();
        }

        /// <summary>
        /// function to initialize product list
        /// </summary>
        private async void InitialProductList()
        {
            //initialize the product list
            if (_collections.Products == null)
            {
                _collections.Products = new List<IProduct>();
            }
        }

        /// <summary>
        /// add new function
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <returns>new created Id</returns>
        public async Task<int> Add(string name, string description, double price)
        {
            // generate an Id
            int newId = await UtilityFactory.GenerateId(_collections.Products);

            _collections.Products.Add(new Product()
            {
                Id = newId,
                Name = name,
                Description = description,
                Price = price
            });
            return newId;
        }
    }
}
