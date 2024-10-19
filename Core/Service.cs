using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Core
{
    public class Service
    {
        public int Id { get; init; }
        public string Name { get; }
        public decimal Price { get; }

        public ProductCategory Category;
        public Service(int id, string name, decimal price, ProductCategory category)
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
