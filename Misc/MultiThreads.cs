namespace MultiThreads;
class Program
{
    private static object _locker = new object();
    private static Random _rand = new Random();
    private const int MAX = 10;

    private static List<int> _numbers = new List<int>();
    private static List<int> _sums = new List<int>();

    private static bool _producerTurn = true;
    
    static void Main()
    {
        Thread t1 = new Thread(Produce);
        Thread t2 = new Thread(Consume);
        
        t1.Start();
        t2.Start();
        
        t1.Join();
        t2.Join();

        foreach (int number in _sums)
        {
            Console.Write($"{number} ");
        }
        Console.WriteLine();
    }

    private static void Produce()
    {
        for (int i = 0; i < 5; i++)
        {
            lock (_locker) 
            {
                while(!_producerTurn) Monitor.Wait(_locker); 
                
                _numbers.Clear();
                while (_numbers.Count < MAX)
                {
                    _numbers.Add(_rand.Next(100));
                }

                Console.WriteLine("Producer: Added 10 numbers. Waiting for Consumer...\n");
                _producerTurn = false;
                Monitor.Pulse(_locker);
            }
            
            Thread.Sleep(200);
        }
    }

    private static void Consume()
    {
        for (int i = 0; i < 5; i++)
        {
            lock (_locker)
            {
                while (_producerTurn)
                {
                    Monitor.Wait(_locker);
                    Console.WriteLine("Producer: Notified by Consumer. Continuing...");
                }

                Console.WriteLine("Consumer: Detected 10 items. Calculating sum...");
                int sum = _numbers.Sum();
                _sums.Add(sum);

                Console.WriteLine($"Consumer: Sum = {sum}. Notifying Producer...\n");
                _producerTurn = true;
                Monitor.Pulse(_locker);
            }
            
            Thread.Sleep(200);
        }
        
    }
}