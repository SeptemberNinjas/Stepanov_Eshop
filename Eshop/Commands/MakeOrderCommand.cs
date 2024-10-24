using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Commands
{
    internal class MakeOrderCommand
    {
        public const string Name = "ОформитьЗаказ";

        public static string GetInfo()
        {
            return "Оформить заказ из товаров в коризне";
        }

        public static string Execute(List<Order> orders, Cart cart, int orderId, string[]? args)
        {
            if (cart.Items.Count == 0) 
                return "Корзина пуста. Заказ не сформирован";

            orders.Add(new Order(orderId, cart.Items, cart.GetCartTotalCost()));
            
            cart.EmptyCart();
            
            return "Заказ сформирован";
        }
    }
}
