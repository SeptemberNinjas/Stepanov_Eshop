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
        
        public ProductCategory Category;
        public Service(int id, string name, double price, ProductCategory category)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
        }

        public override string? ToString()
        {
            return $"Услуга: {Name}. Стоимость: {Price}. Доступно для товаров категории: {Category}";
        }
    }
}
