using Core;
using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Eshop.DAL.Json
{
    public class CartJsonRepository : IRepository<Cart>
    {
        private const string CartPath = "C:\\Users\\user\\source\\repos\\Eshop\\Eshop\\data\\cart.json";
        public IReadOnlyCollection<Cart> GetAll()
        {
            return (IReadOnlyCollection<Cart>)GetCart();
        }

        public Cart? GetByID(int id)
        {
            return GetAll().FirstOrDefault();
        }

        public int GetCount()
        {
            return 1;
        }
        public void Insert(Cart item)
        {
            throw new NotImplementedException();
        }
        
        private static IEnumerable<Cart> GetCart()
        {
            if (!File.Exists(CartPath))
            {
                using var sw = new StreamWriter(CartPath);
                sw.WriteLine("[]");
            }
            
            var str = File.ReadAllText(CartPath);
            var result = JsonSerializer.Deserialize<IEnumerable<Cart>>(str);

            //Cart cart = new Cart(result.ToList<ItemsListLine<SaleItem>>());

            return (IEnumerable<Cart>)result;

        }

        //public void Update(IEnumerable<SaleItem> items)
        //public void Update(IReadOnlyCollection<ItemsListLine<SaleItem>> items)
        public void Update(List<ItemsListLine<SaleItem>> items)
        {
            if (!File.Exists(CartPath))
            {
                using var sw = new StreamWriter(CartPath);
                sw.WriteLine("[]");
            }
            string jsonStr = JsonSerializer.Serialize(items);
            var result = JsonSerializer.Deserialize<List<ItemsListLine<SaleItem>>>(jsonStr);
            File.WriteAllText(CartPath, jsonStr);

        }

    }
}
