namespace PaymentSystem;

class Program
{
    interface IPaymentSystem 
    {
        void ProcessPayment(decimal amount);
    }
    abstract class PaymentSystem: IPaymentSystem 
    {
        protected string SendingAccountNumber { get; private set; }
        protected string ReceivingAccountNumber { get; private set; }
        
        protected PaymentSystem(string sendingAccountNumber, string receivingAccountNumber)
        {
            SendingAccountNumber = sendingAccountNumber;
            ReceivingAccountNumber = receivingAccountNumber;
        }
        public abstract void ProcessPayment(decimal amount);
        
    }
    class Account
    {
        public decimal Balance { get; private set; } 
        public string AccountNumber { get; private set; }
        public string FullName { get; private set; }
        
        public Account(decimal balance, string fullName)
        {
            Random rand = new Random();
            AccountNumber = rand.Next(10001, 99999).ToString();
            
            Balance = balance;
            FullName = fullName;
            
            AccountManagement.AddAccount(this);
        }

        public void UpdateBalance(decimal amount)
        {
            Balance += amount;
        }
        public override string ToString()
        {
            return $"{FullName}: #{AccountNumber} - {Balance}$";
        }
        
    }
    class AccountManagement
    {
        private static int _capacity = 10;
        private static int _size = 0;
        private static Account[] _accountDatas = new Account[_capacity];

        public static void AddAccount(Account account)
        {
            if (_size >= _capacity)
            {
                _capacity *= 2;
                Array.Resize(ref _accountDatas, _capacity);
            }
            
            _accountDatas[_size] = account;
            _size++;
        }

        public static void RemoveAccount(Account account)
        {
            int index = AccountIndex(account);
            if(index == -1) return;

            for (int i = index; i < _size - 1; i++)
            {
                _accountDatas[i] = _accountDatas[i + 1];
            }
            
            _accountDatas[_size - 1] = null;
            _size--;
        }

        public static void PrintAccounts()
        {
            for (int i = 0; i < _size; i++)
            {
                Console.WriteLine(_accountDatas[i].ToString());
            }   
        }
        
        private static int AccountIndex(Account account)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_accountDatas[i] == account) return i;
            }
            return -1;
        }

        public static Account GetAccount(string accountNumber)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_accountDatas[i].AccountNumber == accountNumber) return _accountDatas[i];
            }
            
            return null;
        }

        public static bool AccountExists(string sending, string receiving)
        {
            return (GetAccount(sending) != null) && (GetAccount(receiving) != null) && sending != receiving;
        }
        
    }
    class PayPal : PaymentSystem
    {
        public PayPal(string sendingAccountNumber, string receivingAccountNumber) :
            base(sendingAccountNumber, receivingAccountNumber) {}

        public override void ProcessPayment(decimal amount)
        {
            if (amount <= 0) return;
            if (!AccountManagement.AccountExists(SendingAccountNumber, ReceivingAccountNumber))
            {
                Console.WriteLine("Transaction failed there is no such accounts");
                return;
            }
            
            Account sender = AccountManagement.GetAccount(SendingAccountNumber);
            Account receiver = AccountManagement.GetAccount(ReceivingAccountNumber);

            if (sender.Balance < amount)
            {
                Console.WriteLine("Transaction failed, not enough funds");
                return;
            }
            
            sender.UpdateBalance(-amount);
            receiver.UpdateBalance(amount);
            
            Console.WriteLine($"Transaction successful! {amount}$ transferred from {sender.FullName} to {receiver.FullName}.");
        }

    }

    class CreditCard : PaymentSystem
    {
        public CreditCard(string sendingAccountNumber, string receivingAccountNumber) :base(sendingAccountNumber, receivingAccountNumber) {}

        public override void ProcessPayment(decimal amount)
        {
            if (amount <= 0) return;
            if (!AccountManagement.AccountExists(SendingAccountNumber, ReceivingAccountNumber))
            {
                Console.WriteLine("Transaction failed there is no such accounts");
                return;
            }
            
            Account sender = AccountManagement.GetAccount(SendingAccountNumber);
            Account receiver = AccountManagement.GetAccount(ReceivingAccountNumber);
            
            sender.UpdateBalance(-amount);
            receiver.UpdateBalance(amount);
            
            Console.WriteLine($"Transaction successful! {amount}$ transferred from {sender.FullName} to {receiver.FullName}.");
        }
    }

    class BitCoin : PaymentSystem
    {
        public BitCoin(string sendingAccountNumber, string receivingAccountNumber) : base(sendingAccountNumber,
            receivingAccountNumber)
        {
        }

        private static void BitCoinConverter(ref decimal amount)
        {
            if (amount < 0) return;
            amount /= 50000;
        }

        private static void UsdtConverter(ref decimal amount)
        {
            if (amount < 0) return;
            amount *= 50000;
        }

        public override void ProcessPayment(decimal amount)
        {
            if (amount <= 0) return;
            if (!AccountManagement.AccountExists(SendingAccountNumber, ReceivingAccountNumber))
            {
                Console.WriteLine("Transaction failed there is no such accounts");
                return;
            }

            Account sender = AccountManagement.GetAccount(SendingAccountNumber);
            Account receiver = AccountManagement.GetAccount(ReceivingAccountNumber);

            UsdtConverter(ref amount);

            if (sender.Balance < amount)
            {
                Console.WriteLine("Transaction failed, not enough funds");
                return;
            }

            sender.UpdateBalance(-amount);
            receiver.UpdateBalance(amount);

            BitCoinConverter(ref amount);

            Console.WriteLine(
                $"Transaction successful! {amount} BitCoin transferred from {sender.FullName} to {receiver.FullName}.");
        }
    }

    static void Main()
    {
        Console.WriteLine();
        
        Account ac1 = new Account(2000, "Rud Tadevosyan");
        Account ac2 = new Account(33000, "James Bond");
        Account ac3 = new Account(55000, "Donald Trump");
        Account ac4 = new Account(45000, "Jon Jones");
        
        AccountManagement.PrintAccounts();
        AccountManagement.RemoveAccount(ac3);
        
        Console.WriteLine("\nAfter removing Donald Trump\n");
        AccountManagement.PrintAccounts();
        Console.WriteLine();

        PayPal transaction1 = new PayPal(ac4.AccountNumber, ac2.AccountNumber);
        transaction1.ProcessPayment(45000);
        Console.WriteLine(ac2);
        Console.WriteLine(ac4);
        
        Console.WriteLine();
        PayPal transaction2 = new PayPal(ac3.AccountNumber, ac2.AccountNumber);
        transaction2.ProcessPayment(55000);
        
        PayPal transaction3 = new PayPal(ac1.AccountNumber, ac2.AccountNumber);
        transaction3.ProcessPayment(50000);
        
        Console.WriteLine();
        BitCoin transaction4 = new BitCoin(ac2.AccountNumber, ac1.AccountNumber);
        transaction4.ProcessPayment(1);
        
        BitCoin transaction5 = new BitCoin(ac2.AccountNumber, ac4.AccountNumber);
        transaction5.ProcessPayment((decimal)0.5);
        
        AccountManagement.PrintAccounts();
        Console.WriteLine();
        
        CreditCard transaction6 = new CreditCard(ac2.AccountNumber, ac1.AccountNumber);
        transaction6.ProcessPayment(ac2.Balance);
        
        CreditCard transaction7 = new CreditCard(ac4.AccountNumber, ac1.AccountNumber);
        transaction7.ProcessPayment(ac4.Balance);
        
        Console.WriteLine();
        AccountManagement.PrintAccounts();
        

    }
}