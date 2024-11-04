using Core;
using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.DAL.Memory
{
    public class ServiceMemoryRepository : IRepository<Service>
    {
        private readonly List<Service> _services = new List<Service>();

        private readonly List<ProductCategory> categories = new List<ProductCategory>();

        public ServiceMemoryRepository()
        {
            AddSampleCategories();
            AddSampleServices();
        }

        public IReadOnlyCollection<Service> GetAll()
        {
            return _services.AsReadOnly();
        }

        public Service? GetByID(int id)
        {
            return _services.FirstOrDefault(item => item.Id == id);
        }

        public int GetCount()
        {
            return _services.Count;
        }

        private void AddSampleServices(int countSamples = 10)
        {

            _services.Add(new Service(0, "Замена экрана", 5000, categories[0]));
            _services.Add(new Service(1, "Замена экрана", 10_000, categories[2]));
            _services.Add(new Service(2, "Ремеонт батареии", 3000, categories[0]));
            _services.Add(new Service(3, "Чистка клавиатуры", 1500, categories[2]));
            _services.Add(new Service(4, "Диагностика", 8000, categories[1]));

        }

        private void AddSampleCategories()
        {
            categories.Add(new ProductCategory(1, "Смартфоны"));
            categories.Add(new ProductCategory(2, "Холодильники"));
            categories.Add(new ProductCategory(3, "Ноутбуки"));
        }
    }
}
