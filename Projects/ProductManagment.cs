namespace ProductManagment;

class Program
{
    public class Product
    {
        public string? Name { get; set; }
        private float Price { get; set; }
        private int StockCount  { get; set; }

        
        
        public Product(string name, float price, int stockCount)
        {
            if (stockCount < 0)
            {
                Console.WriteLine("Stock count must be between 0 and 5000");
                return;
            }

            if (price < 0)
            {
                Console.WriteLine("Price must be a positive number");
                return;
            }
            
            Name = name;
            Price = price;
            StockCount = stockCount;
        }

        public void AddStock(int quantity)
        {
            if (quantity < 0)
            {
                Console.WriteLine("Input can not be negative");
                return;
            }
            
            StockCount += quantity;
            Console.WriteLine("Stock added");
            
        }

        public void SellStock(int quantity)
        {
            if (quantity < 0)
            {
                Console.WriteLine("Input can not be negative");
                return;
            }

            if (StockCount - quantity < 0)
            {
                Console.WriteLine("Not enough Product");
                return;
            }
            
            StockCount -= quantity;
            Console.WriteLine($"Product sold for {Price * quantity}$");
        }

        public string ProductInfo()
        {
            return $"Name: {Name} Price: {Price} Stock Count: {StockCount}";
        }

    }

    public class InventoryManager
    {
        private Product?[] Products;
        private static int _index;
        private static int _size = 10;
        
        public InventoryManager()
        {
            Products = new Product[_size];
        }

        private void AddProduct()
        {
            if (_index >= _size)
            {
                _size *= 2;
                Array.Resize(ref Products, _size);
            }
            
            string? name;
            float price;
            int stockCount;
            
            do
            {
                Console.Write("Input a product name to add: ");
                name = Console.ReadLine();
            }while (string.IsNullOrEmpty(name));
            
            Console.Write("Input a product price: ");
            while (!float.TryParse(Console.ReadLine(), out  price) || price < 0)
            {
                Console.Write("Invalid input\nInput a product price: ");
            }

            Console.Write("Input a product stock count: ");
            while (!int.TryParse(Console.ReadLine(), out stockCount) || stockCount < 0)
            {
                Console.Write("Invalid input\nInput a product stock count: ");
            }
            
            Products[_index] = new Product(name, price, stockCount);
            _index++;
            
            Console.WriteLine("Product added");
        }

        private void DisplayAllProducts()
        {
            Console.WriteLine("\nDisplaying all products...");
            if (_index == 0)
            {
                Console.WriteLine("No products available");
                return;
            }

            for (int i = 0; i < _index; i++)
            {
                if (Products[i] != null) 
                {
                    Console.WriteLine(Products[i]?.ProductInfo());
                }
            }
        }

        private bool TryGetProduct(string name, out Product? refProduct)
        {
            refProduct = null;
            for (int i = 0; i < _index; i++)
            {
                if (Products[i] != null && string.Equals(Products[i]?.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    refProduct = Products[i];
                    return true;
                }
            }
            return false;
        }
        private void RemoveProduct()
        {
            if (_index == 0)
            {
                Console.WriteLine("No products available");
                return;
            }
            string? name;
            do
            {
                Console.Write("Input a product name to remove: ");
                name = Console.ReadLine();
            }while(string.IsNullOrEmpty(name));
            
            
            if (!TryGetProduct(name, out Product? refProduct))
            {
                Console.WriteLine("There is no product");
                return;
            }

            int removeIndex = -1;
            
            for (int i = 0; i < _index; i++)
            {
                if (Products[i] != null && Products[i] == refProduct)
                {
                    removeIndex = i;
                }
            }
            
            for (int i = removeIndex; i < _index - 1; i++)
            {
                Products[i] = Products[i + 1];
            }
            
            Products[_index - 1] = null;
            _index--;
            
            Console.WriteLine("Product removed");
        }

        private void AddProductStock()
        {
            if (_index == 0)
            {
                Console.WriteLine("No stock available");
                return;
            }
            
            string? name;
            do
            {
                Console.Write("\nInput a product name to add the stock: ");
                name = Console.ReadLine();
            }while(string.IsNullOrEmpty(name));

            if (!TryGetProduct(name, out Product? refProduct))
            {
                Console.WriteLine("There is no such a product");
                return;
            }

            int quantity;
            Console.Write("Input a product quantity: ");
            while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
            {
                Console.Write("Invalid input\nInput a product quantity: ");
            }
            
            refProduct?.AddStock(quantity);
            
            Console.WriteLine("Stock added");
        }

        private void SellingProduct()
        {
            if (_index == 0)
            {
                Console.WriteLine("No stock available");
                return;
            }
            
            string? name;
            do
            {
                Console.Write("\nInput a product name to sell: ");
                name = Console.ReadLine();
            }while(string.IsNullOrEmpty(name));

            if (!TryGetProduct(name, out Product? refProduct))
            {
                Console.WriteLine("There is no such a product");
                return;
            }

            int quantity;
            Console.Write("Input a product quantity: ");
            while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
            {
                Console.Write("Invalid input\nInput a product quantity: ");
            }
            
            refProduct?.SellStock(quantity);
        }

        public void SelectAnOption()
        {
            Console.Write("\nHi, Select an option\n\nDisplay All Products [1]\nAdd Product [2]\nRemove Product [3]\n" +
                          "Update stock [4]\nSelling product [5]\n\nTo quit press [0] ");
            int option;

            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.Write("Invalid input\nInput a option: ");
            }

            switch (option)
            {
                case 0:
                    Console.WriteLine("\nQuitting the program...");
                    return;
                case 1:
                    DisplayAllProducts();
                    break;
                case 2:
                    AddProduct();
                    break;
                case 3:
                    RemoveProduct();
                    break;
                case 4:
                    AddProductStock();
                    break;
                case 5:
                    SellingProduct();
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
            
            SelectAnOption();
        }
        
    }
    
    static void Main(string[] args)
    {
        InventoryManager manager = new InventoryManager();
        manager.SelectAnOption();
    }
}
