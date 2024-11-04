using Core;
using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.DAL.Json
{
    public class JsonRepositoryFactory : RepositoryFactory
    {
        public override IRepository<Product> CreateProductRepository()
        {
            return new ProductJsonRepository();
        }

        public override IRepository<Service> CreateServiceRepository()
        {
            return new ServiceJsonRepository();
        }
    }
}
