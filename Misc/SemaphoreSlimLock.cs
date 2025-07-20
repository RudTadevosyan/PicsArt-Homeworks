namespace SemaphoreSlimLock;

class Program
{
    private static SemaphoreSlim _semaphore = new SemaphoreSlim(4);
    private static object _locker = new object();
    
    private static int[] _tickets = new int[100];
    
    static void Main(string[] args)
    {
        for (int i = 0; i < _tickets.Length; i++)
        {
            _tickets[i] = 1;
        }

        Thread[] threads = new Thread[10];
        for (int i = 0; i < threads.Length; i++)
        {
            int tmp = i;
            threads[i] = new Thread(() => Buying(tmp));
            threads[i].Start();
        }

        foreach (var t in threads)
        {
            t.Join();
        }
    }

    private static void Buying(int threadId)
    {
        _semaphore.Wait();
        lock (_locker)
        {
            bool bought = false;
            
            for (int i = 0; i < _tickets.Length; i++)
            {
                if (_tickets[i] == 1)
                {
                    _tickets[i] = 0;
                    bought = true;
                    Console.WriteLine($"Ticket {i} has been bought by {threadId} thread");
                    break;
                }
            }
            
            if(!bought) Console.WriteLine("Not enough tickets...");
        }
        
        Thread.Sleep(1000);
        _semaphore.Release();
        
    }
    
    
}