using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Commands
{
    internal class PayOrderCommand
    {
        public const string Name = "ОплатитьЗаказ";

        public static string GetInfo()
        {
            return "Оплатить выбранный заказ. Для оплаты необходимо указать id заказа, тип расчета \"Наличный\"/\"Безналичный\" и вносимую сумму.";
        }

        public static string Execute(List<PaymentCheck> paymentChecks, int paymentId, Order? order, string[]? args)
        {
            if (order == null)
                return "Некорректно указан заказ";

            if (args == null || args.Length < 3)
                return "Некоректно переданы параметры";

            var paymentType = (args[1] == "Наличный") ? PaymentTypes.cash : PaymentTypes.cashless;
            PaymentCheck paymentCheck = new(paymentId, paymentType, order.Id, order.Cost);

            decimal change = 0;
            var message = "";
            var orderIsPaid = paymentCheck.Pay(order, decimal.Parse(args[2]), out change, out message);

            if (orderIsPaid)            
                paymentChecks.Add(paymentCheck);

            return message;
        }
    }
}
