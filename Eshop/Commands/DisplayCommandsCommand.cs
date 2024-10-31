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
                $"{AddItemToCartCommand.Name} - {AddItemToCartCommand.GetInfo()}",
                $"{ShowCartCommand.Name} - {ShowCartCommand.GetInfo()}",
                $"{EmptyCartCommand.Name} - {EmptyCartCommand.GetInfo()}",
                $"{MakeOrderCommand.Name} - {MakeOrderCommand.GetInfo()}",
                $"{ShowOrdersCommand.Name} - {ShowOrdersCommand.GetInfo()}",
                $"{PayOrderCommand.Name} - {PayOrderCommand.GetInfo()}",
                $"{ExitCommand.Name} - {ExitCommand.GetInfo()}"
            };

            return string.Join(Environment.NewLine, strings);

        }
    }
}
