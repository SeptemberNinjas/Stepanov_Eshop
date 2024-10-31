using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Core
{
    /// <summary>
    /// Услуга
    /// </summary>
    public class Service : SaleItem
    {
        public Service(int id, string name, decimal price, ProductCategory category) : base(id, name, price, category)
        {
        }

        /// <summary>
        /// Тип - услуга
        /// </summary>
        public override ItemTypes Type => ItemTypes.Service;

        public override string? ToString()
        {
            return $"Услуга: {Name}. Стоимость: {Price}. Доступно для товаров категории: {Category}";
        }

        /// <summary>
        /// Признак, может ли в корзине быть несколько штук данной торговой единицы
        /// </summary>
        public override bool OnlyOneItem => true;

    }
}
