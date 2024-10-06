using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Service
    {
        public int Id;
        public string Name;
        public double Price;
        public double Stock;
        
        public ProductCategory Category;
        public Service(int id, string name, double price, double stock, ProductCategory category)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
            Category = category;
        }
    }
}
