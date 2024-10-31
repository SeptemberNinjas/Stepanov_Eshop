using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Core
{
    /// <summary>
    /// Услуга
    /// </summary>
    public class Service
    {

        /// <summary>
        /// ID услуги
        /// </summary>
        public int Id { get; init; }
        
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Цана
        /// </summary>
        public decimal Price { get; }

        
        /// <summary>
        /// Категория
        /// </summary>
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
