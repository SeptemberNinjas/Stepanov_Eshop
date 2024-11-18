using Core;
using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.DAL.Json
{
    public class ItemsListLineEntity
    {
        public ItemTypes ItemType { get; set; }
        public Product? Product { get; set; }
        public Service? Service { get; set; }
        public int Count { get; set; }

        public static implicit operator ItemsListLine<SaleItem>(ItemsListLineEntity entity)
        {
            return entity.ItemType == ItemTypes.Product
                ? new ItemsListLine<SaleItem>(entity.Product!, entity.Count)
                : new ItemsListLine<SaleItem>(entity.Service!, 1);
        }

        public static explicit operator ItemsListLineEntity(ItemsListLine<SaleItem> line)
        {
            return new ItemsListLineEntity
            {
                ItemType = line.itemType,
                Product = line.itemType is ItemTypes.Product ? line.LineItem as Product: null,
                Service = line.itemType is ItemTypes.Service ? line.LineItem as Service : null,
                Count = line.Count
            };
        }
    }
}
