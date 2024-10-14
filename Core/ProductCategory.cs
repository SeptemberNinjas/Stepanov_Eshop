using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Core
{
    public class ProductCategory
    {
        public int Id;
        public string Name;
        public ProductCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string? ToString()
        {
            return Name;
        }
    }
}
