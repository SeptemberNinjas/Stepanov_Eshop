using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ProductCategory
    {
        private int _id { get => _id; set => _id = value; }
        private string _name { get => _name; set => _name = value; }
        public ProductCategory(int id, string name)
        {
            _id = id;
            _name = name;
        }

    }
}
