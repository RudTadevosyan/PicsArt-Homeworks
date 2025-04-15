namespace ShopPriceEvent;

class Shop
{
    
    public event EventHandler<DiscountChangedEventArgs> DiscountChanged; 
    public string Name { get; private set; }

    private int _discount;
    public int Discount
    {
        get => _discount;
        set
        {
            if (value != _discount)
            {
                OnDiscountChanged(_discount, value);
                _discount = value;
            }
        }
    }

    public Shop(string name, int discount)
    {
        Name = name;
        Discount = discount;
    }

    public virtual void OnDiscountChanged(int oldDiscount, int newDiscount)
    {
        DiscountChanged?.Invoke(this, new DiscountChangedEventArgs(oldDiscount, newDiscount));
    }

    public void ChangeDiscount(int newDiscount)
    {
        Discount = newDiscount;
    }
    
}

class DiscountChangedEventArgs : EventArgs
{
    public int OldDiscount { get; }
    public int NewDiscount { get; }

    public DiscountChangedEventArgs(int oldDiscount, int newDiscount)
    {
        OldDiscount = oldDiscount;
        NewDiscount = newDiscount;
    }
    
}
sealed class Customer
{
    public string Name { get; private set; }

    public Customer(string name)
    {
        Name = name;
    }

    public void OnDiscountChanged(object? sender, DiscountChangedEventArgs e)
    {
        Console.WriteLine($"{Name} says that {sender.GetType().Name}'s discount changed from {e.OldDiscount}% to {e.NewDiscount}%.");
    }
    
}

class Program
{
    static void Main()
    {
        Shop shop = new Shop("MyShop", 10);

        Customer c1 = new Customer("Alice");
        Customer c2 = new Customer("John");
        Customer c3 = new Customer("Andrew");
        
        shop.DiscountChanged += c1.OnDiscountChanged;
        shop.DiscountChanged += c2.OnDiscountChanged;
        shop.DiscountChanged += c3.OnDiscountChanged;
        
        shop.ChangeDiscount(20);
        Console.WriteLine();
        shop.ChangeDiscount(15);
        
    }
}