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
        public int ItemID => (_product?.Id ?? _service?.Id) ?? throw new();
        public ItemType itemType => _product != null ? ItemType.Product : ItemType.Service;
        public string Text => $"{(_product?.Name ?? _service?.Name)} Количество: {Count} шт.";

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

        public decimal GetItemPrice()
        {
 
            return _product != null ? _product.Price : _service.Price;

        }

    }
}
