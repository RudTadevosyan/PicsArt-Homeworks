namespace TimeConv;

class Program
{
    static void TimeConvertor(ref int totalSeconds, out float totalHours, out float totalMinutes)
    {
        totalMinutes = totalSeconds / 60f;
        totalHours = totalSeconds / 3600f;
    }
    static void Main(string[] args)
    {
        Console.Write("Input a total seconds: ");
        int totalSeconds;

        while(!int.TryParse(Console.ReadLine(), out totalSeconds) || totalSeconds < 0)
        {
            Console.WriteLine("Invalid input, try again");
            Console.Write("Input a total seconds: ");
        }

        float totalHours, totalMinutes;

        TimeConvertor(ref totalSeconds, out totalHours, out totalMinutes);

        Console.WriteLine($"\nTotal seconds: {totalSeconds}\nTotal hours: {totalHours:F2}\nTotal minutes: {totalMinutes:F2}");

    }
}
