﻿namespace FactorialFuncMemoizing;

class Program
{
    static void Main()
    {
        /* You pass the raw factorial code to memoize
        memoize creates a new function that has:
        Caching logic
        A call to your original raw factorial logic when needed
        That new function (factorial code wrapped with cache logic) is returned and assigned to factorial */
        
        Func<Func<int, long>, Func<int, long>> memoize = fn =>
        {
            var cache = new Dictionary<int, long>();
            return (int index) =>
            {
                if(cache.ContainsKey(index)) return cache[index];
                long result = fn(index);
                cache[index] = result;
                return result;
            };
        };
        
        Func<int, long> factorial = memoize( (int n) =>
        {
            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        });

        Console.WriteLine(factorial(5));
        Console.WriteLine(factorial(7));
        
    }
}
