namespace GenericTransformer;

public delegate T Transform<T>(T input);


class Program
{

    private static void UpperCaseString(Transform<string> fn, List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = fn(list[i]);
        }
    }
    
    static void Main()
    {
        List<string> names = ["James", "Richard", "Andrew", "Joseph", "Ashot"];
        Transform<string> uppercase = (input) => input.ToUpper();
    
        UpperCaseString(uppercase, names);

        foreach (var item in names)
        {
            Console.WriteLine(item);
        }

    }
}