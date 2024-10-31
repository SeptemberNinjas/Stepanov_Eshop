using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Order
    {
        public int Id { get; init; }
        public decimal Cost { get; init; }
        public OrderStatuses Status { get; set; }

        private readonly List<ItemsListLine<SaleItem>> _items;
        public List<ItemsListLine<SaleItem>> Items => _items;          
        public int PaymentCheckId { get; set; }
        public Order(int id, List<ItemsListLine<SaleItem>> items, decimal cost)
        {
            Id = id;
            _items = new List<ItemsListLine<SaleItem>>(items);
            Cost = cost;
            Status = OrderStatuses.newOrder;
        }

        public override string? ToString()
        {
            var orderInfo = new StringBuilder();
            orderInfo.AppendLine($"Заказ {Id} включает {_items.Count} товар(ов)/ услуг:");
            
            foreach (var item in _items)
                orderInfo.AppendLine(item.Text);

            var statusToShow = (Status == OrderStatuses.newOrder) ? "Новый" : "Оплачен";
            orderInfo.AppendLine($"Статус: {statusToShow}");
            orderInfo.AppendLine($"Стоимость заказа: {Cost}");

            return orderInfo.ToString();
        }
    }
}
