using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.DAL.Json
{
    public class CartEntity
    {
        public IEnumerable<ItemsListLineEntity> Lines { get; init; }

        public static implicit operator Cart(CartEntity entity)
        {
            return new Cart(entity.Lines
                .Select(l => (ItemsListLine<SaleItem>)l));
        }

        public static explicit operator CartEntity(Cart cart)
        {
            return new CartEntity
            {
                Lines = cart.Items.Select(l => (ItemsListLineEntity)l)
            };
        }
    }
}
