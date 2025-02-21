//Solving the problem with -  ref and out!
using System;
namespace QuadricEquation;
class Program
{

    static void HowManyRoots(ref double a, ref double b, ref double c, out int flagNumberOfRoots)
    {
        double disc = b * b - 4 * a * c;

        if(disc > 0)
        {
            flagNumberOfRoots = 2;
        }
        else if(disc == 0)
        {
            flagNumberOfRoots = 1;
        }
        else
        {
            flagNumberOfRoots = 0;
        }
    }

    static void QuadricEquation2Roots(ref double a, ref double b, ref double c, out double x1, out double x2)
    {
        double disc = b * b - 4 * a * c;

        x1 = (-b + Math.Sqrt(disc))/2 * a;
        x2 = (-b - Math.Sqrt(disc))/2 * a;
    }

    static void QuadricEquation1Root(ref double a, ref double b, out double x)
    {
        x = (-b)/ 2 * a;
    } 

    static void Main(string[] args)
    {
        Console.WriteLine("Please input for quadric equation a, b, c: ");

        double a,b,c;

        Console.Write("Input a number for a: ");
        while(!double.TryParse(Console.ReadLine(), out a))
        {
            Console.WriteLine("Invalid input, try again");
            Console.Write("Input a number for a: ");
        }

        Console.Write("Input a number for b: ");
        while(!double.TryParse(Console.ReadLine(), out b))
        {
            Console.WriteLine("Invalid input, try again");
            Console.Write("Input a number for b: ");
        }

        Console.Write("Input a number for c: ");
        while(!double.TryParse(Console.ReadLine(), out c))
        {
            Console.WriteLine("Invalid input, try again");
            Console.Write("Input a number for c: ");
        }

        int flagNumberOfRoots;

        HowManyRoots(ref a, ref b, ref c, out flagNumberOfRoots);

        if(flagNumberOfRoots == 2)
        {
            double x1, x2;
            QuadricEquation2Roots(ref a, ref b, ref c, out x1, out x2);

            Console.WriteLine($"\nThe roots: {x1} {x2}");
        }
        else if (flagNumberOfRoots == 1)
        {
            double x;
            QuadricEquation1Root(ref a, ref b, out x);

            Console.WriteLine($"\nThe root: {x}");

        }
        else
        {
            Console.WriteLine("\nThere is no solution");
        }
    

        
    }
}
