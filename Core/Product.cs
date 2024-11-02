
using Core;

namespace Eshop.Core
{
    /// <summary>
    /// Товары
    /// </summary>
    public class Product : SaleItem
    {

        private int stock;
        
        /// <summary>
        /// Остаток
        /// </summary>
        public int Stock
        {
            get => stock;
            set => stock = value < 0 ? 0 : value;
        }

        public Product(int id, string name, decimal price, ProductCategory category, int stock) : base(id, name, price, category)
        {
            Stock = stock;

        }

        /// <summary>
        /// Тип продукт
        /// </summary>
        public override ItemTypes Type => ItemTypes.Product;

        public override string? ToString()
        {
            return $"ID: {Id} Товар: {Name}.\nКатегория: {Category}.\nСтоимость: {Price}.\nКоличество: {Stock}";
        }
    }
}
