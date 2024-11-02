using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class CartItem
    {
        private readonly Product? _product;
        private readonly Service? _service;
        private int _count;
        
        /// <summary>
        /// ID линии
        /// </summary>
        public int ItemID => (_product?.Id ?? _service?.Id) ?? throw new();
        
        /// <summary>
        /// Тип торговой единицы
        /// </summary>
        public ItemTypes itemType => _product != null ? ItemTypes.Product : ItemTypes.Service;
        
        /// <summary>
        /// Представление торговой единицы
        /// </summary>
        public string Text => $"{(_product?.Name ?? _service?.Name)} Количество: {Count} шт.";

        /// <summary>
        /// Колиество единиц
        /// </summary>
        public int Count
        {
            get { return _count; }
            set
            {
                if (value < 1)
                    return;
                
                _count = value;
             
            }
        }

        public CartItem(Product? product, int count)
        {
            _product = product;
            Count = count;
        }

        public CartItem(Service? service)
        {
            _service = service;
            Count = 1;
        }

        /// <summary>
        /// Получение стоимости линии
        /// </summary>
        /// <returns></returns>
        public decimal GetItemPrice()
        {
 
            return _product != null ? _product.Price : _service.Price;

        }

    }
}
