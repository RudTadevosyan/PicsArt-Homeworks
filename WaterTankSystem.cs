namespace WaterTankSystem;

class Program
{
    public class WaterTank
    {
        private double Capacity { get; }
        private double CurrentLevel { get; set; }

        public WaterTank(double capacity, double currentLevel)
        {
            Capacity = capacity;
            CurrentLevel = currentLevel;
        }

        public override string ToString()
        {
            return $"Capacity: {Capacity}, CurrentLevel: {CurrentLevel}";
        }

        public static WaterTank operator +(WaterTank a, WaterTank b)
        {
            if (a.CurrentLevel + b.CurrentLevel > a.Capacity)
            {
                b.CurrentLevel -= (a.Capacity - a.CurrentLevel);
                a.CurrentLevel = a.Capacity;
            }
            else
            {
                a.CurrentLevel += b.CurrentLevel;
                b.CurrentLevel = 0;
            }
            
            return new WaterTank(a.Capacity, a.CurrentLevel);
        }
        
        public static WaterTank operator +(WaterTank a, double amount)
        {
            if (a.CurrentLevel + amount > a.Capacity)
            {
                a.CurrentLevel = a.Capacity;
            }
            else
            {
                a.CurrentLevel += amount;
            }
            
            return new WaterTank(a.Capacity, a.CurrentLevel);
        }

        public static WaterTank operator -(WaterTank a, double consume)
        {
            if (a.CurrentLevel < consume)
            {
                a.CurrentLevel = 0;
            }
            else
            {
                a.CurrentLevel -= consume;
            }
            
            return new WaterTank(a.Capacity, a.CurrentLevel);
        }
    }

    static void Main()
    {
        WaterTank first = new WaterTank(100, 55);
        WaterTank second = new WaterTank(70, 25);
        
        Console.WriteLine($"\n{first}");
        Console.WriteLine(second);

        Console.WriteLine($"\nfirst + second: I {first + second} -- II {second}");
        Console.WriteLine($"\nsecond + first: II {second + first} -- I {first}");
        Console.WriteLine($"\nfirst - 20: I {first - 20} -- II {second + 30}");
        Console.WriteLine($"\nfirst + 55: I {first + 45} -- II {second - 25} ");
        
        Console.WriteLine($"\nfirst + second: I {first + second} -- II {second}");
        
    }
}