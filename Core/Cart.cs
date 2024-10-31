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
        private readonly List<ItemsListLine<SaleItem>> _items = new List<ItemsListLine<SaleItem>>();
        
        /// <summary>
        /// Список торговых единиц в корзине
        /// </summary>
        public List<ItemsListLine<SaleItem>> Items => _items;
        
        /// <summary>
        /// Добавить товар в корзину в указанном количестве
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

            ItemsListLineSaleItem? foundedItem;
            var itemFound = TryGetItem(product.Id, ItemTypes.Product, out foundedItem);

            if (itemFound && foundedItem != null)
                foundedItem.Count += count;
            else
                _items.Add(new ItemsListLineSaleItem(product, count));

            return "Товар успешно добавлен в корзину";
        }

        /// <summary>
        /// Добавить услугу в корзину
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public string AddItem(Service service)
        {
            var answerText = "";

            ItemsListLineSaleItem? foundedItem;
            var itemFound = TryGetItem(service.Id, ItemTypes.Service, out foundedItem);

            if (itemFound && service.OnlyOneItem)
            {
                answerText = "Услуга уже добавлена в корзину";

            } else
            {
                _items.Add(new ItemsListLineSaleItem(service));
                answerText = "Услуга успешно добавлена в корзину";
            }

            return answerText;
        }

        /// <summary>
        /// Проверка наличия торговой единицы в корзине
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="itemType"></param>
        /// <param name="foundedItem"></param>
        /// <returns></returns>
        public bool TryGetItem(int itemID, ItemTypes itemType, out ItemsListLineSaleItem? foundedItem)
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
                    foundedItem = (ItemsListLineSaleItem)item;
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
        /// Общая стоимость всех торговых единиц в корзине
        /// </summary>
        /// <returns></returns>
        public decimal GetCartTotalCost()
        {
            decimal totalCost = 0;
            foreach (var item in _items)
                totalCost += item.GetItemPrice() * item.Count;

            return totalCost;
        }
    }
}
