using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ItemsListLineSaleItem : ItemsListLine<SaleItem>
    {
        public ItemsListLineSaleItem(Product product, int count) : base(product, count) { }

        public ItemsListLineSaleItem(Service service) : base(service, 1) { }

    }
}
