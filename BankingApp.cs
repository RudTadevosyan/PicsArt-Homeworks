using System;
namespace BankingApp;

class Program
{
    public class BankAccount
    {
        public string AccountNumber;
        public string HolderName;
        public int Balance;

        public BankAccount(string accountNumber, string holderName, int balance)
        {
            AccountNumber = accountNumber;
            HolderName = holderName;
            Balance = balance;
        }

        public void Deposit(int amount)
        {
            Balance += amount;
        }

        public void Withdraw(int amount)
        {
            if(amount > Balance)
            {
                Console.WriteLine("Insufficent funds");
            }

            Balance -= amount;
        }

        public void DisplayAccountInfo(){
            Console.WriteLine($"Account number & Holder's name:{AccountNumber + " "} {HolderName}\nBalance: {Balance}");
        }

    }

    static void Main(string[] args)
    {

        
        BankAccount[] bankAccounts = new BankAccount[2];
        Random random= new Random();

        Console.Write("Create 2 bank accounts\nFor quiting press 'x'\nPress any key to continue...  ");
        char ch = Console.ReadKey().KeyChar;
        ch = char.ToLower(ch);

        Console.WriteLine();

        if(ch == '\0' || ch == 'x')
        {
            return;
        }

        for(int i = 0; i < 2; i++){
        Console.WriteLine();
        string accountNumber = random.Next(10001,100000).ToString();
        Console.WriteLine($"Bank Account {i + 1}:\nYour Account Number#: {accountNumber}\n");
            
            string? holderName;
            do
            {
                Console.Write("Input holder's name: ");
                holderName = Console.ReadLine();
            }while(string.IsNullOrEmpty(holderName));

            bankAccounts[i] = new BankAccount(accountNumber, holderName, 0);
        }

        Console.WriteLine();

        while(true)      
        {
            Console.Write("\nHi if you want to make banking operation please press 'y': \nif you want to quit press 'x'\n\n\n[y][x]: ");
            char option = Console.ReadKey().KeyChar;
            Console.WriteLine();

            option = char.ToLower(option);

            switch(option)
            {
                case 'y':
                    string? holderName;
                    do
                    {
                        Console.Write("Please input your name: ");
                        holderName = Console.ReadLine();
                    }while(string.IsNullOrEmpty(holderName));

                    int flagFound = 0;
                    for(int i = 0; i < bankAccounts.Length; i++)
                    {
                        if(bankAccounts[i].HolderName == holderName)
                        {
                            
                            string? accountNumber;
                            do
                            {
                                Console.Write("Input your account number: ");
                                accountNumber = Console.ReadLine();
                            }while(string.IsNullOrEmpty(accountNumber));

                            int attempts = 3;

                            while(accountNumber != bankAccounts[i].AccountNumber)
                            {
                                Console.WriteLine($"Wrong account number, please try again {attempts} attempts");
                                do
                                {
                                    Console.Write("Input your account number: ");
                                    accountNumber = Console.ReadLine();
                                }while(string.IsNullOrEmpty(accountNumber));
                                
                                attempts--;
                                if(attempts == 0)
                                {
                                    Console.WriteLine("Operation failed!");
                                    return;
                                }
                            }

                            char operation;
                            Console.WriteLine("Select an operation");

                            do{
                                Console.Write("Deposit(1), Withdraw(2), Display Balance(3): ");
                                operation = Console.ReadKey().KeyChar;
                            }while(char.IsWhiteSpace(operation) && operation != '1' && operation != '2' && operation != '3');

                            Console.WriteLine();
                            Console.WriteLine();

                                                     
                            if(operation == '1')
                            {
                                int amount = 0;
                                Console.Write("Input an amount to deposit: ");
                                while(!int.TryParse(Console.ReadLine(), out amount))
                                {
                                    Console.Write("Input can't be empty\nInput an amount to deposit: ");
                                }

                                bankAccounts[i].Deposit(amount);
                                Console.WriteLine("Operation succeded!");
                            }
                            else if(operation == '2')
                            {
                                int amount = 0;
                                Console.Write("Input an amount to withdraw: ");
                                while(!int.TryParse(Console.ReadLine(), out amount))
                                {
                                    Console.WriteLine("Input can't be empty");
                                }

                                bankAccounts[i].Withdraw(amount);
                            }
                            else if(operation == '3')
                            {
                                bankAccounts[i].DisplayAccountInfo();
                            }
                            else
                            {
                                Console.WriteLine("Error!");
                            }
                                

                            flagFound = 1;
                            break;
                        }
                    }

                    if(flagFound == 0)
                    {
                        Console.WriteLine("There is no bank account with your name");
                    }
                    break;

                case 'x':
                    return;
                default:
                    Console.WriteLine("Please press 'y' or 'x'");
                    break;
            }

        }



    }
}
