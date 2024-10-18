using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Commands
{
    internal static class DisplayCommandsCommand
    {
        public const string Name = "Команды";

        public static string GetInfo()
        {
            return "Список команд.";
        }

        public static string Execute()
        {
            var strings = new string[] {
                $"{Name} - {GetInfo()}",
                $"{ShowProductsCommand.Name} - {ShowProductsCommand.GetInfo()}",
                $"{ShowServicesCommand.Name} - {ShowServicesCommand.GetInfo()}",
                $"{ExitCommand.Name} - {ExitCommand.GetInfo()}"
            };

            return string.Join(Environment.NewLine, strings);

        }
    }
}
