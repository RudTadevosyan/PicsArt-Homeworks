using System.Threading.Channels;

namespace FactorialFuncMemoizing;

class Program
{
    static void Main()
    {
        
        Func<Func<int, int>, Func<int, int>> memoize = fn =>
        {
            var cache = new Dictionary<int, int>();
            return (int index) =>
            {
                if(cache.ContainsKey(index)) return cache[index];
                int result = fn(index);
                cache[index] = result;
                return result;
            };
        };
        
        Func<int, int> factorial = memoize( (int n) =>
        {
            int result = 1;
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