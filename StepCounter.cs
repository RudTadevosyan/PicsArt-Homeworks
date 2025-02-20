namespace StepCounter;

class Program
{
public class SmartWatchSteps
{

    private string OwnerName;
    private int StepCounter;

    public SmartWatchSteps(string ownerName)
    {
        this.OwnerName = ownerName;
        this.StepCounter = 0;
    }

    public void AddSteps()
    {
        Console.Write("\nInput a number of steps you did: ");
        int steps;
        while(!int.TryParse(Console.ReadLine(), out steps) || steps < 0)
        {
            Console.WriteLine("Invalid Input, try again");
            Console.Write("Input a number of steps you did: ");
        }

        this.StepCounter += steps;

        Console.Write("\nDo you want to update your step count?\nPress [y] to continue or other symbol to quit: ");
        char choice = Console.ReadKey().KeyChar;
        choice = char.ToLower(choice);

        if(choice == 'y')
        {
            this.AddSteps();
        }

    }

    public void ShowSteps()
    {
        Console.WriteLine($"\nYou did overall {this.StepCounter} steps!");
    }
}


    static void Main(string[] args)
    {
        
        string? ownerName;
        do
        {
            Console.Write("Input your name to create an account: ");
            ownerName = Console.ReadLine();
        }while(string.IsNullOrEmpty(ownerName));



        SmartWatchSteps watch = new SmartWatchSteps(ownerName);

        watch.AddSteps();
        watch.ShowSteps();


    }


}
