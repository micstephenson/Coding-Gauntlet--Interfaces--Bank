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
        var Mortgageaccount1 = new MortgageAccount();
        accounts.Add(Currentaccount1);
        accounts.Add(Currentaccount2);
        accounts.Add(Savingsaccount1);
        accounts.Add(Savingsaccount2);
        //accounts.Add(Mortgageaccount1);

        var (outstanding, paid) = Mortgageaccount1.GetBalances();
        //Console.WriteLine($"Mortgage Account \nOutstanding balance: {outstanding}, Balance Paid: {paid}");

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