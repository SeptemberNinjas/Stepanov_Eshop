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
        private readonly List<CartItem> _items;
        public List<CartItem> Items => _items;
        public Order(int id, List<CartItem> items)
        {
            Id = id;
            _items = new List<CartItem>(items);
        }
    }
}
