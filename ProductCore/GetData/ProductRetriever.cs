using ProductCore.GetData;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCore
{
    public class ProductRetriever : IProductRetriever
    {
        private readonly ICollections _collections;
        public ProductRetriever(ICollections collections) {
            _collections = collections;
        }

        /// <summary>
        /// get product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>product</returns>
        public async Task<IProduct> Get(int id)
        {
            return _collections.Products.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// get all products
        /// </summary>
        /// <returns>collection of products</returns>
        public async Task<IList<IProduct>> GetAll()
        {
            return _collections.Products.ToList();
        }

        /// <summary>
        ///  get all products if they contain the search text
        /// </summary>
        /// <param name="name"></param>
        /// <returns>collection of products</returns>
        public async Task<IList<IProduct>> GetByName(string name)
        {
            return _collections.Products.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}
