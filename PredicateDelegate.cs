namespace PredicateDelegate;

class Program
{
    static void Main()
    {
        List<int> numbers = [38, 27, 342, 3, 9, 82, 10, 101, 1, 3, 14];
        Predicate<int> even = x  => (x & 1) == 0;
        
        EvenPrint(even, numbers);

    }

    private static void EvenPrint(Predicate<int> fn, List<int> numbers)
    {
        foreach (int num in numbers)
        {
            if(fn(num)) Console.WriteLine(num);
        }
    }
}