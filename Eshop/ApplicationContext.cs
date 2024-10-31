﻿using Core;
using Eshop.Commands;
using Eshop.Core;
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

        private readonly List<Product> products = new List<Product>();
        private readonly List<Service> services = new List<Service>();
        private readonly List<ProductCategory> categories = new List<ProductCategory>();
        private Cart cart = new Cart();
        private List<Order> orders = new List<Order>();
        private int orderIndex = 0;
        private List<PaymentCheck> paymentChecks = new List<PaymentCheck>();
        private int paymentId = 0;

        public ApplicationContext()
        {
            AddSampleCategories();
            AddSampleProducts();
            AddSampleServices();
        }

        public string ExecuteStartUpCommand()
        {
            return ExecuteCommandByName(DisplayCommandsCommand.Name);
        }

        public string ExecuteCommandByName(string command, string[]? args = null)
        {
            var commantToExecute = "";

            switch (command)
            {
                case DisplayCommandsCommand.Name:
                    commantToExecute = DisplayCommandsCommand.Execute();
                    break;
                case ExitCommand.Name:
                    commantToExecute = ExitCommand.Execute();
                    break;
                case ShowProductsCommand.Name:
                    commantToExecute = ShowProductsCommand.Execute(products, args);
                    break;
                case ShowServicesCommand.Name:
                    commantToExecute = ShowServicesCommand.Execute(services, args);
                    break;
                case AddItemToCartCommand.Name:
                    if (args != null && args.Length >= 1 && args[0] == "Товар")
                        commantToExecute = AddItemToCartCommand.Execute(cart, products, args);
                    else
                        commantToExecute = AddItemToCartCommand.Execute(cart, services, args);
                    break;
                case ShowCartCommand.Name:
                    commantToExecute = ShowCartCommand.Execute(cart, args);
                    break;
                case EmptyCartCommand.Name:
                    commantToExecute = EmptyCartCommand.Execute(cart, args);
                    break;
                case MakeOrderCommand.Name:
                    commantToExecute = MakeOrderCommand.Execute(orders, cart, ref orderIndex, args);
                    break;
                case ShowOrdersCommand.Name:
                    commantToExecute = ShowOrdersCommand.Execute(orders, args);
                    break;
                case PayOrderCommand.Name:
                    if (args != null && args.Length >= 3)
                    {
                        int orderIDToSeek = int.Parse(args[0]);
                        Order foundOrder = FindOrderByID(orderIDToSeek);
                        commantToExecute = PayOrderCommand.Execute(paymentChecks, paymentId, foundOrder, args);
                    }
                    else
                    {
                        commantToExecute = "Неправильно переданы параметры команды";
                    }                    
                    
                    break;

                default:
                    commantToExecute = "Неизвестная команда";
                    break;
            };

            return commantToExecute;

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

        private void AddSampleCategories()
        {
            categories.Add(new ProductCategory(1, "Смартфоны"));
            categories.Add(new ProductCategory(2, "Холодильники"));
            categories.Add(new ProductCategory(3, "Ноутбуки"));
        }

        private void AddSampleProducts(int countSamples = 10)
        {
            Random random = new Random();

            for (int i = 0; i < countSamples; i++)
            {
                var numCategory = random.Next(categories.Count);
                var category = categories[numCategory];

                var productName = category.Name.Substring(0, category.Name.Length - 1) + " " + i;

                var price = random.Next(100, 2000) * 100;
                var stock = random.Next(101);

                products.Add(new Product(i, productName, price, category, stock));
            }
        }

        private void AddSampleServices(int countSamples = 10)
        {

            services.Add(new Service(0, "Замена экрана", 5000, categories[0]));
            services.Add(new Service(1, "Замена экрана", 10_000, categories[2]));
            services.Add(new Service(2, "Ремеонт батареии", 3000, categories[0]));
            services.Add(new Service(3, "Чистка клавиатуры", 1500, categories[2]));
            services.Add(new Service(4, "Диагностика", 8000, categories[1]));

        }

    }
}
