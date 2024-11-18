using Core;
using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.DAL.Memory
{
    public class ProductMemoryRepository : IRepository<Product>
    {
        private readonly List<Product> _products = new List<Product>();

        private readonly List<ProductCategory> categories = new List<ProductCategory>();
        
        public ProductMemoryRepository()
        {
            AddSampleCategories();
            AddSampleProducts();
        }

        public IReadOnlyCollection<Product> GetAll()
        {
            return _products.AsReadOnly();
        }

        public int GetCount()
        {
            return _products.Count;
        }

        public Product? GetByID(int id)
        {
            return _products.FirstOrDefault(item => item.Id == id);
        }

        public void Insert(Product item)
        {
            _products.Add(item);
        }
        
        private void AddSampleCategories()
        {
            categories.Add(new ProductCategory(1, "Смартфоны"));
            categories.Add(new ProductCategory(2, "Холодильники"));
            categories.Add(new ProductCategory(3, "Ноутбуки"));
        }

        private void AddSampleProducts(int countSamples = 10)
        {
            Random random = new Random();

            for (int i = 0; i < countSamples; i++)
            {
                var numCategory = random.Next(categories.Count);
                var category = categories[numCategory];

                var productName = category.Name.Substring(0, category.Name.Length - 1) + " " + i;

                var price = random.Next(100, 2000) * 100;
                var stock = random.Next(101);

                _products.Add(new Product(i, productName, price, category, stock));
            }
        }

        public void Update(Product item)
        {
            throw new NotImplementedException();
        }

        int IRepository<Product>.Insert(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
