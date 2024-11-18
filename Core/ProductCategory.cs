using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        public int Id { get; set; }
        
        /// <summary>
        /// Имя категории
        /// </summary>
        public string Name { get; set; }
        public ProductCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public ProductCategory()
        {
        }

        public override string? ToString()
        {
            return Name;
        }
    }
}
