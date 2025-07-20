namespace BasicCalculator;

class Program
{
    public class BasicCalculator
    {
        public static double Result = 0;
        public static bool FirstOperation = true;
        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Divide(double a, double b)
        {
            if(b == 0)
            {
                Console.WriteLine("Can't divide on 0!");
                return 0;
            }
            return a / b;
        }

        public static void Calculator()
        {
            Console.Write("\nChoose an operation (+, -, *, /) or press 'x' to quit: ");
            char operation = Console.ReadKey().KeyChar;

            if(operation == 'x')
            {
                Console.WriteLine("\nExiting calculator...");
                return;
            }
            
            double a, b;

            if(FirstOperation)
            {
                Console.Write("\nInput a number: ");
                while(!double.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine("Invalid Input, try again");
                    Console.Write("Input a number: ");
                }

                Result = a;
                FirstOperation = false;
            }

            a = Result;

            Console.Write("\nInput a number: ");
            while(!double.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Invalid Input, try again");
                Console.Write("Input a number: ");
            }

            

            switch (operation)
            {
                case 'x':
                    Console.WriteLine("\nExiting calculator...");
                    return;
                case '+':
                    Result = Add(a,b);
                    break;
                case '-':
                    Result = Subtract(a,b);
                    break;
                case '*':
                    Result = Multiply(a,b);
                    break;
                case '/':
                    if(b != 0)
                    {
                        Result = Divide(a,b);
                    }
                    else
                    {
                        Console.WriteLine("\nCan't divide on 0!");
                        return;
                    }

                    break;
                default:
                    Console.WriteLine("Invalid Input!");
                    return;

            }

            Console.WriteLine($"\nThe result: {Result}\n");

            Calculator();
        
        }
    }
    static void Main(string[] args)
    {
        BasicCalculator.Calculator();

    }
}
