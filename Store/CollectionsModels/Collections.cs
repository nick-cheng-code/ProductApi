using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Collections : ICollections
    {
        public IList<IProduct> Products { get; set; }
    }
}
