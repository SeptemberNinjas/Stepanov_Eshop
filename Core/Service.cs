using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Service
    {
        private int _id { get => _id; set => _id = value; }
        private string _name { get => _name; set => _name = value; }
        private double _price { get => _price; set => _price = value; }
        private double _stock { get => _stock; set => _stock = value; }
        private ProductCategory _category { get => _category; set => _category = value; }
        public Service(int id, string name, double price, double stock, ProductCategory category)
        {
            _id = id;
            _name = name;
            _price = price;
            _stock = stock;
            _category = category;
        }
    }
}
