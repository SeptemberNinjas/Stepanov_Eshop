using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class PaymentCheck
    {
        public int Id { get; init; }
        public PaymentTypes PaymentType { get; init; }
        public int OrderID { get; init; }       
        public decimal PaymentAmount { get; init; }
        public Boolean IsCompleted { get; private set; }
        public PaymentCheck(int id, PaymentTypes paymentType, int orderID, decimal paymentAmount)
        {
            Id = id;
            PaymentType = paymentType;
            OrderID = orderID;
            PaymentAmount = paymentAmount;
        }
        public string Pay(Order order, decimal paymentAmount, out decimal change)
        {
            change = 0;

            if (paymentAmount < this.PaymentAmount)
            {
                return "Недостаточно средств для оплаты.";
            }

            change = this.PaymentAmount - paymentAmount;
            IsCompleted = true;

            order.Status = OrderStatuses.paidOrder;

            return "Заказ оплачен.";
        }
    }
}
