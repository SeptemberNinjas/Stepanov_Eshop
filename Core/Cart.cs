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
        private readonly List<CartItem> _items = new List<CartItem>();
        public List<CartItem> Items => _items;
        public string AddItem(Product product, int count)
        {
            if (count < 1)
                return "Нужно больше 0";

            if (product.Stock < count)
                return "Не хватает товара";

            product.Stock -= count;

            CartItem foundedItem = null;
            var itemAlreadyAdded = ItemAlreadyAdded(product.Id, ItemType.Product, out foundedItem);

            if (itemAlreadyAdded && foundedItem != null)
            {
                foundedItem.Count += count;

            } else
            {
                CartItem cartItem = new CartItem(product, count);
                _items.Add(cartItem);
            }

            return "Товар успешно добавлен в корзину";
        }

        public string AddItem(Service service)
        {
            var answerText = "";

            CartItem foundedItem = null;
            var itemAlreadyAdded = ItemAlreadyAdded(service.Id, ItemType.Service, out foundedItem);

            if (itemAlreadyAdded)
            {
                answerText = "Услуга уже добавлена в корзину";

            } else
            {
                CartItem cartItem = new CartItem(service);
                _items.Add(cartItem);
                answerText = "Услуга успешно добавлена в корзину";
            }

            return answerText;
        }

        public Boolean ItemAlreadyAdded(int itemID, ItemType itemType, out CartItem? foundedItem)
        {
            var alreadyExist = false;
            foundedItem = null;
            foreach (var item in _items)
            {
                if (item.itemType != itemType)
                    continue;

                if (item.ItemID == itemID)
                {
                    alreadyExist = true;
                    foundedItem = item;
                    break;
                }
            }

            return alreadyExist;
        }

        public string EmptyCart()
        {
            _items.Clear();
            return "Корзина очищена";
        }
        public decimal GetCartTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (var item in _items)
                totalPrice += item.GetItemPrice() * item.Count;

            return totalPrice;
        }
    }
}
