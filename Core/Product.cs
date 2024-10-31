
namespace Eshop.Core
{
    /// <summary>
    /// Товар
    /// </summary>
    public class Product
    {
        /// <summary>
        /// ID товара
        /// </summary>
        public int Id { get; init; }
        
        /// <summary>
        /// Имя товара
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Цена товара
        /// </summary>
        public decimal Price { get; }

        private int stock;
        
        /// <summary>
        /// Количество
        /// </summary>
        public int Stock
        {
            get => stock;
            set => stock = value < 0 ? 0: value;
        }
        
        /// <summary>
        /// Категория
        /// </summary>
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
