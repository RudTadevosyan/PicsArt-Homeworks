namespace DelegateTasks;

class Program
{
    private delegate double Operation(double a, double b);
    
    static void Main()
    {
        
        Operation add = (a, b) => a + b;
        Operation subtract = (a, b) => a - b;
        Operation multiply = (a, b) => a * b;
        Operation divide = (a, b) => a / b;

        Console.WriteLine(add(5,6));
        Console.WriteLine(subtract(5,6));
        Console.WriteLine(multiply(5,6));
        Console.WriteLine(divide(5,6));
    }
}