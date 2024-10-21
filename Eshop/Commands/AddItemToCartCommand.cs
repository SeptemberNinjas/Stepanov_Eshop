using Core;
using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Commands
{
    internal class AddItemToCartCommand
    {
        public const string Name = "ДобавитьВКорзину";

        public static string GetInfo()
        {
            return "Добавление товара/ услуги в корзину. После команды укажите добавляемый тип - \"Товар\" или \"Услуга\", " +
                   "\nID товара/ услуги для добавления и, если необходимо, количество товара (минимум 1).";
        }

        public static string Execute(Cart? cart, List<Product> products, string[]? args)
        {
            if (cart == null)
                return "Проблемы с корзиной";

            var itemId = 0;
            if (args == null || !int.TryParse(args[1], out itemId) || itemId <= 0)
                return "Некорректно передан Id";

            var countToAdd = 0;
            if (args == null || args.Length < 3 || !int.TryParse(args[2], out countToAdd) || countToAdd <= 0)
                countToAdd = 1;

            Product foundProduct;
            var itemFounded = TryGetItem(itemId, products, out foundProduct);
            if (!itemFounded) 
                return "Товар под таким id не найден";

            return cart.AddItem(foundProduct, countToAdd);

        }

        public static string Execute(Cart? cart, List<Service> services, string[]? args)
        {
            if (cart == null)
                return "Проблемы с корзиной";

            var itemId = 0;
            if (args == null || !int.TryParse(args[1], out itemId) || itemId <= 0)
                return "Некорректно передан Id";

            Service foundService;
            var itemFounded = TryGetItem(itemId, services, out foundService);

            if (!itemFounded)
                return "Услуга под таким id не найдена";

            return cart.AddItem(foundService);

        }

        private static bool TryGetItem<T>(int id, IEnumerable<T> items, out T item) where T : SaleItem
        {
            foreach (var saleItem in items)
            {
                if (saleItem.Id != id)
                    continue;
                item = saleItem;
                return true;
            }

            item = null!;
            return false;

        }


    }
}
