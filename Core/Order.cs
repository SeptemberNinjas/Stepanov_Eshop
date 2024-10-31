using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        /// <summary>
        /// ID заказа
        /// </summary>
        public int Id { get; init; }

        private readonly List<CartItem> _items;
        
        /// <summary>
        /// Список товаров в заказе
        /// </summary>
        public List<CartItem> Items => _items;
        
        public Order(int id, List<CartItem> items)
        {
            Id = id;
            _items = new List<CartItem>(items);
        }
    }
}
