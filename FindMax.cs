namespace MaxNumber;

class Program
{

    static void Max(ref int max, params int[] numbers)
    {
        foreach(int n in numbers)
        {
            if(n > max)
            {
                max = n;
            }
        }

    }
    static void Main(string[] args)
    {
        Console.WriteLine("Hi, input a numbers!");
        int a,b,c;

        Console.Write("Enter a number: ");
        a = int.Parse(Console.ReadLine());
        Console.Write("Enter a number: ");
        b = int.Parse(Console.ReadLine());
        Console.Write("Enter a number: ");
        c = int.Parse(Console.ReadLine());

        int max = a;

        Max(ref max, a, b, c);

        Console.WriteLine($"\nThe max number: {max}");



    }
}
