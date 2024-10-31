using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /// <summary>
    /// Корзина
    /// </summary>
    public class Cart
    {

        /// <summary>
        /// Список товаров в корзине
        /// </summary>
        private readonly List<CartItem> _items = new List<CartItem>();
        public List<CartItem> Items => _items;

        /// <summary>
        /// Добавление товара в корзину, переданного в параметрах в заданном количестве
        /// </summary>
        /// <param name="product"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public string AddItem(Product product, int count)
        {
            if (count < 1)
                return "Нужно больше 0";

            if (product.Stock < count)
                return "Не хватает товара";

            product.Stock -= count;

            CartItem foundedItem = null;
            var itemFound = TryGetItem(product.Id, ItemType.Product, out foundedItem);

            if (itemFound && foundedItem != null)
            {
                foundedItem.Count += count;

            } else
            {
                CartItem cartItem = new CartItem(product, count);
                _items.Add(cartItem);
            }

            return "Товар успешно добавлен в корзину";
        }

        /// <summary>
        /// Добавление в корзину услуги
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public string AddItem(Service service)
        {
            var answerText = "";

            CartItem foundedItem = null;
            var itemFound = TryGetItem(service.Id, ItemType.Service, out foundedItem);

            if (itemFound)
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

        /// <summary>
        /// Проверка наличия товара в корзине
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="itemType"></param>
        /// <param name="foundedItem"></param>
        /// <returns></returns>
        public bool TryGetItem(int itemID, ItemType itemType, out CartItem? foundedItem)
        {
            var itemFound = false;
            foundedItem = null;
            foreach (var item in _items)
            {
                if (item.itemType != itemType)
                    continue;

                if (item.ItemID == itemID)
                {
                    itemFound = true;
                    foundedItem = item;
                    break;
                }
            }

            return itemFound;
        }

        /// <summary>
        /// Очистка корзины
        /// </summary>
        /// <returns></returns>
        public string EmptyCart()
        {
            _items.Clear();
            return "Корзина очищена";
        }

        /// <summary>
        /// Получение общей стоимости товаров в корзине
        /// </summary>
        /// <returns></returns>
        public decimal GetCartTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (var item in _items)
                totalPrice += item.GetItemPrice() * item.Count;

            return totalPrice;
        }
    }
}
