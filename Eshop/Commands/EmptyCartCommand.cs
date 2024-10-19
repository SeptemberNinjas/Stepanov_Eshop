using Core;
using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Commands
{
    internal class EmptyCartCommand
    {
        public const string Name = "ОчиститьКорзину";

        public static string GetInfo()
        {
            return "Очищает коризну от товаров и услуг.";
        }

        public static string Execute(Cart cart, string[]? args)
        {
            cart.EmptyCart();
            return "Корзина очищена";
        }
    }
}
