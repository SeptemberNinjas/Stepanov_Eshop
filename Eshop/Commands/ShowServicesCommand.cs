using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Commands
{
    internal class ShowServicesCommand
    {
        public const string Name = "ПоказатьУслуги";

        public static string GetInfo()
        {
            return "Список услуг. Опционально можно указать количество выводимых услуг.";
        }

        public static void Execute(List<Service> services, int count = 0)
        {
            int countToShow = (count == 0 || count > services.Count()) ? services.Count() : count;

            for (int i = 0; i < countToShow; i++)
                Console.WriteLine(services[i] + "\n");
        }
    }
}
