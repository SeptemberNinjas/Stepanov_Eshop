using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Order
    {
        public int Id { get; init; }
        public decimal Cost { get; init; }
        private readonly List<ItemsListLine<SaleItem>> _items;
        public List<ItemsListLine<SaleItem>> Items => _items;        
        public Order(int id, List<ItemsListLine<SaleItem>> items, decimal cost)
        {
            Id = id;
            _items = new List<ItemsListLine<SaleItem>>(items);
            Cost = cost;
        }
    }
}
