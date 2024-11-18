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
    public class ServiceJsonRepository : IRepository<Service>
    {
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

        private static IEnumerable<Service> GetServices()
        {
            if (!File.Exists("data\\services.json"))
            {
                using var sw = new StreamWriter("data\\services.json");
                sw.WriteLine("[]");
            }

            using var sr = new StreamReader("data\\services.json");

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
