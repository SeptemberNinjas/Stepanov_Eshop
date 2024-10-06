using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Commands
{
    internal static class ShowProducts
    {
        public const string Name = "Показать товары";

        public static string GetInfo()
        {
            return "Показать список товаров. Опционально можно указать количество выводимых товаров.";
        }

        public static void Execute(List<Product> products, int count = 0)
        {
            int countToShow = (count == 0) ? products.Count() : count;

            for (int i = 0; i < countToShow; i++)
                Console.WriteLine(products[i] + "\n");

        }

    }
}
