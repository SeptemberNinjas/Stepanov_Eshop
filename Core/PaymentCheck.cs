using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /// <summary>
    /// Оплата заказа
    /// </summary>
    public class PaymentCheck
    {
        /// <summary>
        /// ID оплаты
        /// </summary>
        public int Id { get; init; }
        
        /// <summary>
        /// Тип оплаты
        /// </summary>
        public PaymentTypes PaymentType { get; init; }
        
        /// <summary>
        /// ID заказа
        /// </summary>
        public int OrderID { get; init; }       
        
        /// <summary>
        /// Сумма платежа
        /// </summary>
        public decimal PaymentAmount { get; init; }
        
        /// <summary>
        /// Признак выполнения оплаты
        /// </summary>
        public bool IsCompleted { get; private set; }
        public PaymentCheck(int id, PaymentTypes paymentType, int orderID, decimal paymentAmount)
        {
            Id = id;
            PaymentType = paymentType;
            OrderID = orderID;
            PaymentAmount = paymentAmount;
        }
        
        /// <summary>
        /// Метод оплаты конкретного заказа на заданную сумму, возврат сдачи и сообщения
        /// </summary>
        /// <param name="order"></param>
        /// <param name="paymentAmount"></param>
        /// <param name="change"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool Pay(Order order, decimal paymentAmount, out decimal change, out string message)
        {
            change = 0;

            if (paymentAmount < this.PaymentAmount)
            {
                message = "Недостаточно средств для оплаты.";
                return false;
            }

            change = paymentAmount - this.PaymentAmount;
            IsCompleted = true;

            order.Status = OrderStatuses.paidOrder;
            order.PaymentCheckId = this.Id;

            message = "Заказ оплачен." + ((change != 0) ? $"Ваша сдача: {change}" : "");

            return true;
        }
    }
}
