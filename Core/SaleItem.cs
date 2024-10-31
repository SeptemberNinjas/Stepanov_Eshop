using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /// <summary>
    /// Торговая единица
    /// </summary>
    public abstract class SaleItem
    {
        /// <summary>
        /// ID торговой единицы
        /// </summary>
        public int Id { get; init; }
        
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// Категория
        /// </summary>
        public ProductCategory Category { get; }
        
        /// <summary>
        /// Тип
        /// </summary>
        public abstract ItemTypes Type { get; }

        protected SaleItem(int id, string name, decimal price, ProductCategory category)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
        }

        /// <summary>
        /// Признак, может ли в корзине быть несколько штук данной торговой единицы
        /// </summary>
        public virtual bool OnlyOneItem => false;

    }
}
