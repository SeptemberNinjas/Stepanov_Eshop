using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Cart
    {
        private readonly List<CartItem> _items;
        public List<CartItem> Items => _items;
        public string AddItem(Product product, int count)
        {
            if (count < 1)
                return "Нужно больше 0";

            if (product.Stock < count)
                return "Не хватает товара";

            product.Stock -= count;
            CartItem cartItem = new CartItem(product, count);
            _items.Add(cartItem);

            return "Товар успешно добавлен в корзину";
        }

        public string AddItem(Service service)
        {
            CartItem cartItem = new CartItem(service);
            _items.Add(cartItem);

            return "Услуга успешно добавлена в корзину";
        }
        public decimal getCartTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (var item in _items)
                totalPrice += item.getItemPrice() * item.Count;

            return totalPrice;
        }
    }
}
