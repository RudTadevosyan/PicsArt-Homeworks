namespace ListsDelegateM;

static class ExtMethods
{
    public static List<T> Map<T>(this List<T> list, Func<T, T> fn)
    {
        List<T> result = new List<T>();
            
        for (int i = 0; i < list.Count; ++i)
        {
            result.Add(fn(list[i]));    
        }
            
        return result;
    }

    public static bool Every<T>(this List<T> list, Func<T, bool> fn)
    {
        foreach (T item in list)
        {
            if (!fn(item))
            {
                return false;
            }
        }
        return true;
    }

    public static bool Some<T>(this List<T> list, Func<T, bool> fn)
    {
        foreach (T item in list)
        {
            if(fn(item)) return true;
        }
        
        return false;
    }
    
}

class Program
{
    static void Main()
    {
        List<int> list = new List<int> { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        var tmp = list.Map(n => n - 1);
        
        Console.WriteLine(tmp[9]);
        Console.WriteLine(tmp.Every(n => n > 0));
        Console.WriteLine(tmp.Some(n => n <= 0));
    }
}