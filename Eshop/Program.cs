
using Core;

namespace Eshop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Product product = new Product(1, "prod1", 10.5, 4, new ProductCategory(1, "holodos"));
            Console.WriteLine(product.Name);
            
            
        }
    }
}
