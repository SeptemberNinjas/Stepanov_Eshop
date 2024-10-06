namespace Core
{
    public class Product
    {
        private int _id { get => _id; set => _id = value; }
        private string _name { get => _name; set => _name = value; }
        private double _price { get => _price; set => _price = value; } 
        private int _stock { get => _stock; set => _stock = value; }
        private ProductCategory _category { get => _category; set => _category = value; }

        public Product(int id, string name, double price, int stock, ProductCategory category)
        {
            _id = id;
            _name = name;
            _price = price;
            _stock = stock;
            _category = category;
        }
    }
}
