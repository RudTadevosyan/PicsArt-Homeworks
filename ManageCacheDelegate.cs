namespace ManageCacheDelegate;

class Program
{
    public delegate void Action(int n);

    public static (Func<int, bool> isPrime, Action ClearCache) ManageCache()
    {
        var cache = new Dictionary<int, bool>();

        Action clearCache = n =>
        {
            if (cache.ContainsKey(n))
            {
                cache.Remove(n);
            }
        };
        
        Func<int, bool> isPrime = n =>
        {
            if (cache.ContainsKey(n))
            {
                bool result = cache[n];
                clearCache(n);
                Console.Write("From cache: ");
                return result;
            }

            if (n < 2)
            {
                cache[n] = false;
                return false;
            }

            for (int i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    cache[n] = false;
                    return false;
                }
            }
            cache[n] = true;
            return true;
        };

        return (isPrime, clearCache);

    }
    
    
    static void Main()
    {
        var fn = ManageCache();
        
        Console.WriteLine(fn.isPrime(5));
        Console.WriteLine(fn.isPrime(5));
        Console.WriteLine(fn.isPrime(5));
    }
}