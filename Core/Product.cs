using System.Xml.Linq;

namespace Core
{
    public class Product
    {
        public int Id;
        public string Name;
        public double Price;
        public int Stock;
        public ProductCategory Category;

        public Product(int id, string name, double price, int stock, ProductCategory category)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
            Category = category;
        }
    }
}
