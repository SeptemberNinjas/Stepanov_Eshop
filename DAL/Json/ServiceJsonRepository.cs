using Core;
using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Eshop.DAL.Json
{
    internal class ServiceJsonRepository : JsonRepository<Service>, IRepository<Service>
    {
        private protected override string ResourceFilePath => "data\\services.json";

        public IReadOnlyCollection<Service> GetAll()
        {
            return (IReadOnlyCollection<Service>)GetServices();
        }

        public Service? GetByID(int id)
        {
            var services = GetServices();
            return services.FirstOrDefault(item => item.Id == id);
        }

        public int GetCount()
        {
            var services = GetServices();
            return services.Count();
        }

        public void Insert(Service item)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Service> GetServices()
        {
            if (!File.Exists(ResourceFilePath))
            {
                using var sw = new StreamWriter(ResourceFilePath);
                sw.WriteLine("[]");
            }

            using var sr = new StreamReader(ResourceFilePath);

            var result = JsonSerializer.Deserialize<IEnumerable<Service>>(sr.BaseStream);

            return (IReadOnlyCollection<Service>)(result ?? []);

        }

        public void Update(Service item)
        {
            throw new NotImplementedException();
        }

        int IRepository<Service>.Insert(Service item)
        {
            throw new NotImplementedException();
        }
    }
}
