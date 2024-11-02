
using Eshop.Core;
using Eshop.Commands;

namespace Eshop
{
    internal class Program
    {
        
        private static readonly ApplicationContext _context = new ApplicationContext();
        static void Main(string[] args)
        {
            
            Console.WriteLine(ApplicationContext.Title);
            Console.WriteLine();
            Console.WriteLine(_context.ExecuteStartUpCommand());

            while (true)
            {
                Console.WriteLine("Введите команду:");
                var command = Console.ReadLine();
                Execute(command);
                Console.WriteLine();
            }
            
        }

        private static void Execute(string? command)
        {

            if (string.IsNullOrWhiteSpace(command))
            {
                Console.WriteLine("Некорректно задана команда");
                return;
            }

            var commandToExecute = command;

            var args = new string[1];
            if (commandToExecute.StartsWith(ShowProductsCommand.Name))
            {
                commandToExecute = ShowProductsCommand.Name;
                args[0] = GetParameterFromCommand(command, 2);
            }
            else if (commandToExecute.StartsWith(ShowServicesCommand.Name))
            {
                commandToExecute = ShowServicesCommand.Name;
                args[0] = GetParameterFromCommand(command, 2);
            }
            else if (commandToExecute.StartsWith(AddItemToCartCommand.Name))
            {
                args = new string[3];
                commandToExecute = AddItemToCartCommand.Name;
                args[0] = GetParameterFromCommand(command, 2);
                args[1] = GetParameterFromCommand(command, 3);
                args[2] = GetParameterFromCommand(command, 4);
            }
            else if (commandToExecute.StartsWith(PayOrderCommand.Name)) 
            {
                args = new string[3];
                commandToExecute = PayOrderCommand.Name;
                args[0] = GetParameterFromCommand(command, 2);
                args[1] = GetParameterFromCommand(command, 3);
                args[2] = GetParameterFromCommand(command, 4);
            }

            Console.WriteLine(_context.ExecuteCommandByName(commandToExecute, args));

        }

        private static string GetParameterFromCommand(string command, int parameterNumber)
        {
            var parameter = "";

            var commandCompound = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (commandCompound.Length >= parameterNumber)
            {
                int parameterIndex = parameterNumber - 1;
                parameter = commandCompound[parameterIndex];
            }

            return parameter;
        }

    }
}
