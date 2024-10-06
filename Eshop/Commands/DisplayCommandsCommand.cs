using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Commands
{
    internal class DisplayCommandsCommand
    {
        public const string Name = "Команды";

        public static string GetInfo()
        {
            return "Показать список команды.";
        }

        public static void Execute()
        {
            Console.WriteLine($"{Name} - {GetInfo()}");
            Console.WriteLine($"{ShowProductsCommand.Name} - {ShowProductsCommand.GetInfo()}");
            Console.WriteLine($"{ShowServicesCommand.Name} - {ShowServicesCommand.GetInfo()}");
            Console.WriteLine($"{ExitCommand.Name} - {ExitCommand.GetInfo()}");
        }
    }
}
