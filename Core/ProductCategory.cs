using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Core
{
    /// <summary>
    /// Категории товаров/ услуг
    /// </summary>
    public class ProductCategory
    {
        /// <summary>
        /// ID категории
        /// </summary>
        public int Id { get; init; }
        
        /// <summary>
        /// Имя категории
        /// </summary>
        public string Name { get; }
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
