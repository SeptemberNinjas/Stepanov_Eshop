using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class SaleItem
    {
        public int Id { get; init; }
        public string Name { get; }
        public decimal Price { get; }

        public ProductCategory Category { get; }
        public abstract ItemTypes Type { get; }

        protected SaleItem(int id, string name, decimal price, ProductCategory category)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
        }

        public virtual bool OnlyOneItem => false;

    }
}
