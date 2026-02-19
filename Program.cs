
using System.Reflection.PortableExecutable;
using System.Collections.Generic;

class Banck {
static List<BankAccount> Accounts = new List<BankAccount>();
BankAccount account1 = new SavingAccount(120, "Mohmed", 4000);

    static int  accountNumber = 100;
    static void Main(string[] args)
    {
        bool run=true;
        while (run)
        {
            Console.WriteLine("----- Bank System -------");
            Console.WriteLine("1.Creat Account");
            Console.WriteLine("2.Deposit");
            Console.WriteLine("3.Withdraw");
            Console.WriteLine("4. View Account Details");
            Console.WriteLine("5.Exit");
            Console.WriteLine("Choose an Option : ");
            string choise=Console.ReadLine();
            switch (choise) {
                case "1":
                    CreatAccount();
                    break;
                case "2":
                    Deposit();
                    break;
                case "3":
                    Withdraw();
                    break;
                case "4":
                    DisplayInf();
                    break;
                case "5":
                    run = false;
                    break;
                default:
                    Console.WriteLine("Invalid choise .. try again");
                    break;
                    
                    
            }

        }
    }

    public static void CreatAccount()
    {
        Console.WriteLine("Enter the Holder Name : ");
        string name = Console.ReadLine();
        Console.WriteLine(" Enter Type of Account 1.Saving Account  2.Current Account");
        string type = Console.ReadLine();
        BankAccount account1;
        accountNumber++;
        if (type == "1")
        {
            account1 = new SavingAccount(accountNumber, name, 0);
        }
        else if (type == "2") {
            account1 = new CurrentAccount(accountNumber, name, 0);


        }
        else { Console.WriteLine("Invalid type");
            return;
        }
        Accounts.Add(account1);
        Console.WriteLine("Account created Successfuly");
    }
    public static void Deposit()
    {
        
        Console.WriteLine("Enter Account Number");
        int id=int.Parse(Console.ReadLine());
        BankAccount account=Accounts.Find(a=>a.AccountNumberId==id) ;
        if (account == null)
        {
            Console.WriteLine("Account is not Found ");
            return;
        }
        
        Console.WriteLine("Enter amount to deposit : ");
        decimal amount = decimal.Parse(Console.ReadLine());
        account.Deposit(amount);
    }
    public static void Withdraw()
    {
        Console.WriteLine("Enter Account Number");
        int id = int.Parse(Console.ReadLine());
        BankAccount account = Accounts.Find(a => a.AccountNumberId == id);
        if (account == null)
        {
            Console.WriteLine("Account is not Found ");
            return;
        }
        Console.WriteLine("Enter amount  : ");
        decimal amount = decimal.Parse(Console.ReadLine());
        account.Withdraw(amount);
    }
    public static void DisplayInf()
    {
        Console.WriteLine("Enter Account Number");
        int id = int.Parse(Console.ReadLine());
        BankAccount account = Accounts.Find(a => a.AccountNumberId == id);
        if (account == null)
        {
            Console.WriteLine("Account is not Found ");
            return;
        }
        Console.WriteLine("Information of your Account");
        account.DisplayInfo();
    }
}

class BankAccount
{
    public int AccountNumberId { get; private set; }
    public string AccountHolderName { get; private set; }
    protected decimal Balance { get; set; }
    public BankAccount(int accountNumberId, string accountHolderName, decimal balance = 0)
    {
        AccountNumberId = accountNumberId;
        AccountHolderName = accountHolderName;
        Balance = balance;
    }
    public void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"Deposit is  {Balance}");
    }
    public virtual void Withdraw(decimal amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            Console.WriteLine($"Withdraw is Successful and the Balance is {Balance}");
        }
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"Account Name is {AccountHolderName}");
        Console.WriteLine($"Account Number is {AccountNumberId}");
        Console.WriteLine($"Balance is {Balance}");
    }
}
class SavingAccount : BankAccount
{
    public SavingAccount(int accountNumberId, string accountHolderName, decimal balance) : base(accountNumberId, accountHolderName, balance)
    {

    }
    public override void Withdraw(decimal amount)
    {
        base.Withdraw(amount);
    }
}
class CurrentAccount : BankAccount
{
    public int OverdraftLimit { get; private set; } = 4000;
    public CurrentAccount(int accountNumberId, string accountHolderName, decimal balance) : base(accountNumberId, accountHolderName, balance)
    {

    }
    public override void Withdraw(decimal amount)
    {
        if (Balance + OverdraftLimit >= amount)
        {
            Console.WriteLine("Waiting......");
            Balance -= amount;
        }
        else
        {
            Console.WriteLine("Overdraft Limit ");
        }
    }

}