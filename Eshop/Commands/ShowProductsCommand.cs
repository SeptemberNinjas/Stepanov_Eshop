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

        public static void Execute(List<Product> products, int count = 0)
        {
            var countToShow = (count <= 0 || count > products.Count) ? products.Count : count;

            for (var i = 0; i < countToShow; i++)
            {
                Console.WriteLine(products[i]);
                Console.WriteLine();
            }
                
        }

    }
}
