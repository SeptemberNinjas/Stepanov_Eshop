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

        public static string Execute(List<Service> services, string[]? args)
        {
            var countToShow = 0;
            if (args == null || !int.TryParse(args[0], out countToShow) || countToShow <= 0 || countToShow > services.Count)
            {
                countToShow = services.Count;
            };
            
            var servicesToShow = new StringBuilder();

            for (int i = 0; i < countToShow; i++)
                servicesToShow.AppendLine(services[i].ToString());
            
            return servicesToShow.ToString();
        }
    }
}
