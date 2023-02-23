using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCore.Utilities
{
    public static class UtilityFactory
    {
        public static async Task<int> GenerateId(IList<IProduct> products)
        {
            return (products?.Count ?? 0) + 1;
        }
    }
}
