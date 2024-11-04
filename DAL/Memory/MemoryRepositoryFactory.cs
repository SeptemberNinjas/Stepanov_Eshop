using Core;
using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.DAL.Memory
{
    public class MemoryRepositoryFactory : RepositoryFactory
    {
        public override IRepository<Product> CreateProductRepository()
        {
            return new ProductMemoryRepository();
        }

        public override IRepository<Service> CreateServiceRepository()
        {
            return new ServiceMemoryRepository();
        }
    }
}
