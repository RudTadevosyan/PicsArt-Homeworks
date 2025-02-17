namespace OnlineShoppingApp;

class Program
{
    public class Product
    {
        public string Name;
        public float Price;
        public int Quantity;

        public Product(string name, float price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public float TotalPrice()
        {
            return Price * Quantity;
        }

    }

    static void Main(string[] args)
    {
        int n = 0;
        Console.Write("How many product you want to buy: ");
        

        while(!int.TryParse(Console.ReadLine(), out n))
        {
            Console.WriteLine("Invalid input!");
            Console.Write("How many products you want to buy: ");
        }

        Console.WriteLine();
        
        if(n <= 0)
        {
            return;
        }

        Product[] shoppingCart = new Product[n];
        Random random = new Random();


        for(int i = 0; i < n; i++)
        {
            Console.WriteLine();
            string? name;
            do{
                Console.Write("Input a product name you want to buy: ");
                name = Console.ReadLine();
            }while(string.IsNullOrEmpty(name));


            float price;
            Console.Write("Enter the price: ");
            while(!float.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid input!");
                Console.Write("Enter the price: ");
            }

            int quantity;
            Console.Write("Enter the quantity: ");
            while(!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Invalid input!");
                Console.Write("Enter the quantity: ");
            }

            shoppingCart[i] = new Product(name, price, quantity);

        }

        float totalPrice = 0f;

        foreach(Product product in shoppingCart)
        {
            totalPrice += product.TotalPrice();
        }

        if(n > 5)
        {
            totalPrice *= 0.9f;
        }

        Console.WriteLine();
        Console.WriteLine($"Total price: {totalPrice}");

    }
}
