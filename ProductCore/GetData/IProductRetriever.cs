using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCore.GetData
{
    public interface IProductRetriever
    {
        Task<IProduct> Get(int id);

        Task<IList<IProduct>> GetByName(string name);

        Task<IList<IProduct>> GetAll();
    }
}
