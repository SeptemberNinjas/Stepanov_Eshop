using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /// <summary>
    /// Линия списка торговой единицы
    /// </summary>
    public class ItemsListLine<T> where T : SaleItem
    {
        private readonly T _lineItem;

        public T LineItem => _lineItem;    
        
        /// <summary>
        /// ID линии
        /// </summary>
        public int ItemID => _lineItem.Id;
        
        /// <summary>
        /// Тип линии
        /// </summary>
        public ItemTypes itemType => _lineItem.Type;
        
        /// <summary>
        /// Представление линии
        /// </summary>
        public string Text => $"{_lineItem.Name} Количество: {Count} шт.";

        /// <summary>
        /// Количество
        /// </summary>
        public int Count { get; set; }

        public ItemsListLine(T lineItem, int count)
        {
            _lineItem = lineItem;
            Count = count;
        }
        public ItemsListLine()
        {
        }

        /// <summary>
        /// Получить стоимость линии
        /// </summary>
        /// <returns></returns>
        public decimal GetItemPrice()
        {
 
            return _lineItem.Price;

        }

    }
}
