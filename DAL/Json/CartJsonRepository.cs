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
    internal class CartJsonRepository : JsonRepository<CartEntity>, IRepository<Cart>
    {     
        private protected override string ResourceFilePath => "data\\cart.json";

        public IReadOnlyCollection<Cart> GetAll() => GetItemsFromFile()
              .Select(b => (Cart)b)
              .ToArray();

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
        
        public void Update(Cart item)
        {
            SaveItemsToFile([(CartEntity)item]);            
        }

        int IRepository<Cart>.Insert(Cart item)
        {
            throw new NotImplementedException();
        }
    }
}
