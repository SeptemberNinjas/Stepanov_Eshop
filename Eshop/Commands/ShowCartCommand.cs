using Core;
using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Commands
{
    internal class ShowCartCommand
    {
        public const string Name = "ПоказатьКорзину";

        public static Cart _cart;
        public ShowCartCommand(IRepository<Cart> cartRepository)
        {
            _cart = cartRepository.GetAll().FirstOrDefault();
        }

        public static string GetInfo()
        {
            return "Корзина с товарами.";
        }

        public string Execute(string[]? args)
        {
            if (_cart == null)
                return "Проблемы с корзиной";
            else if (_cart.Items.Count == 0)
                return "Корзина пуста";

            var carItemsToShow = new StringBuilder();

            foreach (var cartItem in _cart.Items)
            {
                decimal currentCost = cartItem.GetItemPrice() * cartItem.Count;
                carItemsToShow.AppendLine($"{cartItem.Text} Цена за {cartItem.Count} шт: {currentCost}");
            }

            carItemsToShow.AppendLine($"Общая сумма: {_cart.GetCartTotalCost()}");

            return carItemsToShow.ToString();

        }

    }
}
