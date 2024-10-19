using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Commands
{
    internal static class ShowProductsCommand
    {
        public const string Name = "ПоказатьТовары";

        public static string GetInfo()
        {
            return "Список товаров. Опционально можно указать количество выводимых товаров.";
        }

        public static string Execute(List<Product> products, string[]? args)
        {
            var countToShow = 0;
            if (args == null || !int.TryParse(args[0], out countToShow) || countToShow <= 0 || countToShow > products.Count)
            {
                countToShow = products.Count;
            };

            var produtcsToShow = new StringBuilder();

            for (var i = 0; i < countToShow; i++)                
                produtcsToShow.AppendLine(products[i].ToString());

            return produtcsToShow.ToString();


        }

    }
}
