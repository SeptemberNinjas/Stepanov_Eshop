using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ItemsListLine<T> where T : SaleItem
    {
        private readonly T _lineItem;
        public int ItemID => _lineItem.Id;
        public ItemType itemType => _lineItem.Type;
        public string Text => $"{_lineItem.Name} Количество: {Count} шт.";

        public int Count { get; set; }

        public ItemsListLine(T lineItem, int count)
        {
            _lineItem = lineItem;
            Count = count;
        }
        public decimal GetItemPrice()
        {
 
            return _lineItem.Price;

        }

    }
}
