﻿using Core;
using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Eshop.DAL.Json
{
    internal class ProductJsonRepository : JsonRepository<Product>, IRepository<Product>
    {
        private protected override string ResourceFilePath => throw new NotImplementedException();

        public IReadOnlyCollection<Product> GetAll()
        {
            return (IReadOnlyCollection<Product>)GetProducts();
        }

        public Product? GetByID(int id)
        {
            var products = GetProducts();
            return products.FirstOrDefault(item => item.Id == id);
        }

        public int GetCount()
        {
            var products = GetProducts();
            return products.Count();
        }

        public void Insert(Product item)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Product> GetProducts()
        {
            if (!File.Exists("data\\products.json"))
            {
                using var sw = new StreamWriter("data\\products.json");
                sw.WriteLine("[]");
            }

            using var sr = new StreamReader("data\\products.json");            

            var result = JsonSerializer.Deserialize<IEnumerable<Product>>(sr.BaseStream);

            return (IReadOnlyCollection<Product>)(result ?? []);

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
