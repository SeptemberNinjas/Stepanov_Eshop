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

            Product? foundProduct = null;
            foreach (var product in products)
            {
                if (product.Id == itemId)
                {
                    foundProduct = product;
                    break;
                }
            }

            if (foundProduct == null) 
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

            Service? foundService = null;
            foreach (var service in services)
            {
                if (service.Id == itemId)
                {
                    foundService = service;
                    break;
                }
            }

            if (foundService == null)
                return "Услуга под таким id не найдена";

            return cart.AddItem(foundService);

        }

    }
}
