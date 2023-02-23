using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCore.SaveData
{
    public interface IProductCreator
    {
        Task<int> Add(string name, string description, double  price);
    }
}
