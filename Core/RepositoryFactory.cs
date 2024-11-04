using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class RepositoryFactory
    {
        public abstract IRepository<Product> CreateProductRepository();
        public abstract IRepository<Service> CreateServiceRepository();
    }
}
