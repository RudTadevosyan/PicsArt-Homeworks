using System;
namespace BankAccountSystem;

class Program
{
    public class BankAccount
    {
        private int AccountNumber {get; set;}
        private double _balance;
        
        public double Balance 
        {
            get
            {
                return _balance;
            }
            set
            {
                if(value < 0)
                {
                    Console.WriteLine("Can't be negative");
                    return;
                }    
                _balance = value;
            }
            
        }
        
        public BankAccount(int accountNumber, double balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }
        
        public override string ToString()
        {
            return $"Account: {AccountNumber}, Balance: {Balance} USD";
        }
        
        public static bool Equals(BankAccount a, BankAccount b)
        {
            if(a is BankAccount && b is BankAccount){
                return a.AccountNumber == b.AccountNumber;
            }
            return false;
        }
        
        public override int GetHashCode()
        {
            return AccountNumber ^ (int)Balance ^ 17;
        }
        
        public static BankAccount operator +(BankAccount a, double amount)
        {
        
            if(amount < 0)
            {
                Console.WriteLine("Can't be negative");
                return a;
            }
            a.Balance += amount;
            return a;
        }
        
        public static BankAccount operator -(BankAccount a, double amount)
        {
           if(amount < 0)
           {
               Console.WriteLine("Can't be negative");
               return a;
           }
            
           a.Balance -= amount;
           return a;
           
        }
        
        public static bool operator >(BankAccount a, BankAccount b)
        {
            return a.Balance > b.Balance;
        }   
        
        public static bool operator <(BankAccount a, BankAccount b)
        {
            return a.Balance < b.Balance;
        }
        
        public static bool operator >=(BankAccount a, BankAccount b)
        {
            return a.Balance >= b.Balance;
        }    
        
        public static bool operator <=(BankAccount a, BankAccount b)
        {
            return a.Balance <= b.Balance;
        }    
    }
    
    
    
    
    public static void Main(string[] args)
    {

        BankAccount account1 = new BankAccount(1, 500);
        BankAccount account2 = new BankAccount(2, 300);

        Console.WriteLine(account1.ToString());
        Console.WriteLine(account2.ToString());

        account1 += 100;  
        account2 -= 50; 
        
        Console.WriteLine();
        Console.WriteLine(account1.ToString());
        Console.WriteLine(account2.ToString());

        Console.WriteLine();
        Console.WriteLine(account1 < account2);
        Console.WriteLine(account1 > account2);
        Console.WriteLine(BankAccount.Equals(account1, account2));
    }
}