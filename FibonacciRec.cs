namespace Fibonacci;

class Program
{

    static int Fibonacci(int n)
    {
        if(n == 0)
        {
            return 0;
        }

        if(n == 1 || n == 2)
        {
            return 1;
        }

        return Fibonacci(n - 2) + Fibonacci(n - 1);


    }
    static void Main(string[] args)
    {
        Console.Write("Input a index for fibonacci sequance: ");
        int n, res;

        while(!int.TryParse(Console.ReadLine(), out n) || n < 0)
        {
            Console.WriteLine("Invalid input, try again");
            Console.Write("Input a index for fibonacci sequance: ");
        }

        res = Fibonacci(n);

        Console.WriteLine($"\nFibonacci: {res}");

    }
}
