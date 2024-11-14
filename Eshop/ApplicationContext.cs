using Core;
using Eshop.Commands;
using Eshop.Core;
using Eshop.DAL.Json;
using Eshop.DAL.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop
{
    internal class ApplicationContext
    {
        public const string Title = "Интернет-магазин";

        private readonly IRepository<Product> _products;
        private readonly IRepository<Service> _services;
        //private Cart _cart;
        private IRepository<Cart> _cartRepository;

        private List<Order> orders = new List<Order>();
        private int orderIndex = 0;
        private List<PaymentCheck> paymentChecks = new List<PaymentCheck>();
        private int paymentId = 0;

        private readonly RepositoryFactory _repositoryFactory;

        public ApplicationContext()
        {
            _repositoryFactory = new JsonRepositoryFactory();
            _products = _repositoryFactory.CreateProductRepository();
            _services = _repositoryFactory.CreateServiceRepository();
            _cartRepository = _repositoryFactory.CreateCartRepository();
            //_cart = _repositoryFactory.CreateCartRepository().GetByID(0) ?? new Cart();

        }

        public string ExecuteStartUpCommand()
        {
            return ExecuteCommandByName(DisplayCommandsCommand.Name);
        }

        public string ExecuteCommandByName(string command, string[]? args = null)
        {
            var commandToExecute = "";

            var _addItemToCartCommand = new AddItemToCartCommand(_cartRepository);
            var _showCartCommand = new ShowCartCommand(_cartRepository);

            switch (command)
            {
                case DisplayCommandsCommand.Name:
                    commandToExecute = DisplayCommandsCommand.Execute();
                    break;
                case ExitCommand.Name:
                    commandToExecute = ExitCommand.Execute();
                    break;
                case ShowProductsCommand.Name:
                    commandToExecute = ShowProductsCommand.Execute(_products.GetAll().ToList<Product>(), args);
                    break;
                case ShowServicesCommand.Name:
                    commandToExecute = ShowServicesCommand.Execute(_services.GetAll().ToList<Service>(), args);
                    break;
                case AddItemToCartCommand.Name:
                    if (args != null && args.Length >= 1 && args[0] == "Товар")
                        //commandToExecute = AddItemToCartCommand.Execute(_cart, _products.GetAll().ToList<Product>(), args);
                        commandToExecute = _addItemToCartCommand.Execute(_products.GetAll().ToList<Product>(), args);
                    else
                        //commandToExecute = AddItemToCartCommand.Execute(_cart, _services.GetAll().ToList<Service>(), args);
                        commandToExecute = _addItemToCartCommand.Execute(_services.GetAll().ToList<Service>(), args);
                    break;
                case ShowCartCommand.Name:
                    //commandToExecute = ShowCartCommand.Execute(_cart, args);
                    commandToExecute =  _showCartCommand.Execute(args);
                    break;
                case EmptyCartCommand.Name:
                    //commandToExecute = EmptyCartCommand.Execute(_cart, args);
                    commandToExecute = EmptyCartCommand.Execute(_cartRepository.GetByID(0) ?? new Cart(), args);
                    break;
                case MakeOrderCommand.Name:
                    //commandToExecute = MakeOrderCommand.Execute(orders, _cart, ref orderIndex, args);
                    commandToExecute = MakeOrderCommand.Execute(orders, _cartRepository.GetByID(0) ?? new Cart(), ref orderIndex, args);
                    break;
                case ShowOrdersCommand.Name:
                    commandToExecute = ShowOrdersCommand.Execute(orders, args);
                    break;
                case PayOrderCommand.Name:
                    if (args != null && args.Length >= 3)
                    {
                        int orderIDToSeek = int.Parse(args[0]);
                        Order foundOrder = FindOrderByID(orderIDToSeek);
                        commandToExecute = PayOrderCommand.Execute(paymentChecks, paymentId, foundOrder, args);
                    }
                    else
                    {
                        commandToExecute = "Неправильно переданы параметры команды";
                    }                    
                    
                    break;

                default:
                    commandToExecute = "Неизвестная команда";
                    break;
            };

            return commandToExecute;

        }

        private Order FindOrderByID(int orderId)
        {            
            
            foreach (var order in orders)
            {
                if (order.Id == orderId)
                    return order;                
            }

            return null;

        }

    }
}
