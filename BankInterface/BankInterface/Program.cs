using BankInterface.Accounts;
using BankInterface.Interface;

class Program
{
    static void Main(string[] args)
    {
        List <IBankAccount> accounts = new List<IBankAccount>();
        var Currentaccount1 = new CurrentAccount();
        var Currentaccount2 = new CurrentAccount();
        var Savingsaccount1 = new SavingsAccount();
        var Savingsaccount2 = new SavingsAccount();
        accounts.Add(Currentaccount1);
        accounts.Add(Currentaccount2);
        accounts.Add(Savingsaccount1);
        accounts.Add(Savingsaccount2);

        foreach (var account in accounts)
        {
            decimal amount = new Random().Next(100, 1000);
            account.AddMoney(amount);
            Console.WriteLine($"Account: {account.GetCustomerId()}");
            Console.WriteLine($"Account Balance: {account.GetBalance()}");
            account.WithdrawMoney(100);
            Console.WriteLine($"Account Balance after withdrawl: {account.GetBalance()}\n");
        }
    }
}