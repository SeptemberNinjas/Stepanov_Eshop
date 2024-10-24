using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Core
{
    public class Service : SaleItem
    {
        public Service(int id, string name, decimal price, ProductCategory category) : base(id, name, price, category)
        {
        }
        public override ItemTypes Type => ItemTypes.Service;

        public override string? ToString()
        {
            return $"Услуга: {Name}. Стоимость: {Price}. Доступно для товаров категории: {Category}";
        }

        public override bool OnlyOneItem => true;

    }
}
