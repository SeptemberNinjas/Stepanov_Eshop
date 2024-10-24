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
        private readonly List<ItemsListLine<SaleItem>> _items = new List<ItemsListLine<SaleItem>>();
        public List<ItemsListLine<SaleItem>> Items => _items;
        public string AddItem(Product product, int count)
        {
            if (count < 1)
                return "Нужно больше 0";

            if (product.Stock < count)
                return "Не хватает товара";

            product.Stock -= count;

            ItemsListLineSaleItem? foundedItem;
            var itemAlreadyAdded = ItemAlreadyAdded(product.Id, ItemTypes.Product, out foundedItem);

            if (itemAlreadyAdded && foundedItem != null)
                foundedItem.Count += count;
            else
                _items.Add(new ItemsListLineSaleItem(product, count));

            return "Товар успешно добавлен в корзину";
        }

        public string AddItem(Service service)
        {
            var answerText = "";

            ItemsListLineSaleItem? foundedItem;
            var itemAlreadyAdded = ItemAlreadyAdded(service.Id, ItemTypes.Service, out foundedItem);

            if (itemAlreadyAdded && service.OnlyOneItem)
            {
                answerText = "Услуга уже добавлена в корзину";

            } else
            {
                _items.Add(new ItemsListLineSaleItem(service));
                answerText = "Услуга успешно добавлена в корзину";
            }

            return answerText;
        }

        public Boolean ItemAlreadyAdded(int itemID, ItemTypes itemType, out ItemsListLineSaleItem? foundedItem)
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
                    foundedItem = (ItemsListLineSaleItem)item;
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
        public decimal GetCartTotalCost()
        {
            decimal totalCost = 0;
            foreach (var item in _items)
                totalCost += item.GetItemPrice() * item.Count;

            return totalCost;
        }
    }
}
