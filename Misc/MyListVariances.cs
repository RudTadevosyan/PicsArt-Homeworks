using System.Collections;

namespace ListVariances;
interface IReadBox<out T> : IEnumerable
{
    T this[int index] { get; }
}

interface IWriteBox<in T>
{ 
    void Add(T item);
}

sealed class MyList<T> : IReadBox<T>, IWriteBox<T>
{
    private List<T> _list = new List<T>();
    public void Add(T item) => _list.Add(item);

    public T this[int index] => _list[index];
    
    
    public IEnumerator GetEnumerator()
    {
        foreach (var item in _list)
        {
            yield return item;
        }
    }
}

class Program
{
    private static void AddStrings(IWriteBox<string> list)
    {
        list.Add("Hello");
        list.Add("World");
        list.Add("Goodbye");
    }

    private static void Print(IReadBox<object> list)
    {
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
    
    static void Main()
    {
        MyList<object> objects = new MyList<object>();
        IWriteBox<string> strings = objects; //changing object to string (contravariance), saving in less type
        
        AddStrings(objects); //takes object type than converts to string (IWriteBox<string>) 
        Print(objects); // doesn't change anything as Print takes object (IReadBox<object>)
        Console.WriteLine();
        
        MyList<string> strings2 = new MyList<string>();
        IReadBox<object> objects2 = strings2; //changing string to object (covariance), saving in bigger type
        
        AddStrings(strings2); //doesn't change anything as AddString takes string (IWriteBox<string>)
        Print(strings2); // takes string type than converts to object (IReadBox<object>)
        
    }
}