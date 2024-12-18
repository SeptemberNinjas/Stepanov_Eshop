﻿using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Commands
{
    public class ShowOrdersCommand
    {
        public const string Name = "ПоказатьЗаказы";

        public static string GetInfo()
        {
            return "Список заказов.";
        }

        public static string Execute(List<Order> orders, string[]? args)
        {           
            if (orders.Count == 0)
                return "Список заказов пуста";

            var ordersToShow = new StringBuilder();
            foreach (var order in orders)
                ordersToShow.AppendLine(order.ToString());

            return ordersToShow.ToString();

        }
    }
}
