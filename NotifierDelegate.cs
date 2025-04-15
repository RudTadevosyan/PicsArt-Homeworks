namespace NotifierDelegate;

public delegate void MessageHandler(string msg);

sealed class Notifier
{
    private MessageHandler _notify;

    public Notifier(MessageHandler handler)
    {
        _notify = handler;
    }

    public void Notify(string message)
    {
        _notify(message);
    }

    public void ChangeHandler(MessageHandler handler)
    {
        _notify = handler;
    }
    
}

class Program
{
    private static void ConsoleHandler(string msg)
    {
        Console.WriteLine($"Console: {msg}");
    }

    private static void FileLogger(string msg)
    {
        Console.WriteLine($"FileLogger: {msg}");

    }

    private static void EmailSimulation(string msg)
    {
        Console.WriteLine($"EmailSim: {msg}");
    }
    
    static void Main()
    {
        Notifier notifier = new Notifier(ConsoleHandler);
        notifier.Notify("Hello World!");
        
        notifier.ChangeHandler(FileLogger);
        notifier.Notify("Open/Close File");
        
        notifier.ChangeHandler(EmailSimulation);
        notifier.Notify("anyemail@gmail.com");
    }
}