
using Core;
using Eshop.Commands;

namespace Eshop
{
    internal class Program
    {
        private static List<Product> products;
        private static List<Service> services;
        private static List<ProductCategory> categories;
        static void Main(string[] args)
        {

            Init();
            
            AddSampleCategories();
            AddSampleProducts();
            AddSampleServices();

            Console.WriteLine("Консольный интернет-магазин");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("(Для показа всех команд введите \"Команды\". Для выхода введите \"Выход\")");
                Console.WriteLine("Введите команду:");
                var command = Console.ReadLine();
                Execute(command);
                Console.WriteLine();
            }
            
        }

        private static void Execute(string? command)
        {

            var commandToCheck = command;

            var countToShow = 0;
            if (command.StartsWith(ShowProductsCommand.Name))
            {
                commandToCheck = ShowProductsCommand.Name;
                var currentParameter = GetParameterFromCommand(command, 3);
                if (currentParameter != "")
                    countToShow = Convert.ToInt32(GetParameterFromCommand(command, 3));
            } 
            else if (commandToCheck.StartsWith(ShowServicesCommand.Name))
            {
                commandToCheck = ShowServicesCommand.Name;
                var currentParameter = GetParameterFromCommand(command, 3);
                if (currentParameter != "")
                    countToShow = Convert.ToInt32(GetParameterFromCommand(command, 3));
            }

            switch (commandToCheck)
            {
                case DisplayCommandsCommand.Name:
                    Console.WriteLine(DisplayCommandsCommand.GetInfo());
                    Console.WriteLine();
                    DisplayCommandsCommand.Execute();
                    break;
                case ExitCommand.Name:
                    ExitCommand.Execute();
                    break;
                case ShowProductsCommand.Name:
                    Console.WriteLine(ShowProductsCommand.GetInfo());
                    Console.WriteLine();
                    ShowProductsCommand.Execute(products, countToShow);
                    break;
                case ShowServicesCommand.Name:
                    Console.WriteLine(ShowServicesCommand.GetInfo());
                    Console.WriteLine();
                    ShowServicesCommand.Execute(services, countToShow);
                    break;
                default:
                    Console.WriteLine("Неизвестная команда");
                    break;
            };

        }

        private static void AddSampleCategories()
        {
            categories.Add(new ProductCategory(1, "Смартфоны"));
            categories.Add(new ProductCategory(2, "Холодильники"));
            categories.Add(new ProductCategory(3, "Ноутбуки"));
        }

        private static void AddSampleProducts(int countSamples = 10)
        {
            Random random = new Random();
    
            for (int i = 0; i < countSamples; i++)
            {
                var numCategory = random.Next(categories.Count);
                var category = categories[numCategory];
                
                var productName = category.Name.Substring(0, category.Name.Length- 1) + " " + i;

                var price = random.Next(100, 2000) * 100;
                var stock = random.Next(101);

                products.Add(new Product(i, productName, price, stock, category));
            }
        }

        private static void AddSampleServices(int countSamples = 10)
        {
            Random random = new Random();

            services.Add(new Service(0, "Замена экрана", 5000, categories[0]));
            services.Add(new Service(1, "Замена экрана", 10_000, categories[2]));
            services.Add(new Service(2, "Ремеонт батареии", 3000, categories[0]));
            services.Add(new Service(3, "Чистка клавиатуры", 1500, categories[2]));
            services.Add(new Service(4, "Диагностика", 8000, categories[1]));

        }

        private static string GetParameterFromCommand(string command, int parameterNumber)
        {
            var parameter = "";

            var commandCompound = command.Split(' ');
            if (commandCompound.Length >= parameterNumber)
            {
                int parameterIndex = parameterNumber - 1;
                parameter = commandCompound[parameterIndex];
            }

            return parameter;
        }

        private static void Init()
        {
            products = new List<Product>();
            services = new List<Service>();
            categories = new List<ProductCategory>();
        }

    }
}
