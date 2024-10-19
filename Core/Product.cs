
namespace Eshop.Core
{
    public class Product
    {
        public int Id { get; init; }
        public string Name { get; }
        public decimal Price { get; }

        private int stock;
        public int Stock
        {
            get => stock;
            set => stock = value < 0 ? 0: value;
        }
        public ProductCategory Category { get; }

        public Product(int id, string name, decimal price, int stock, ProductCategory category)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
            Category = category;
        }

        public override string? ToString()
        {
            return $"ID: {Id} Товар: {Name}.\nКатегория: {Category}.\nСтоимость: {Price}.\nКоличество: {Stock}";
        }
    }
}
