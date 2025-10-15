using BankInterface.Interface;

namespace BankInterface.Accounts;

internal class SavingsAccount : IBankAccount
{
    private decimal balance;
    private const decimal interestRate = 0.03m;
    private string CustomerId;
    private DateTime AccountAge;
    

    public SavingsAccount(string Id, DateTime Age)
    {
        CustomerId = Id;
        AccountAge = Age;
    }

    public double GetAccountAge(DateTime AccountAge)
    {
        double months = (DateTime.Today.Year - AccountAge.Year) * 12 + DateTime.Today.Month - AccountAge.Month;
        if (DateTime.Today.Day < AccountAge.Day)
        {
            months -= 1;
        }
        return months;
    }

    public void AddMoney(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Amount must be positive.");
        }
        balance += amount;
    }

    public void WithdrawMoney(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Amount must be positive.");
        }
        if (amount > balance)
        {
            Console.WriteLine("Insufficient funds.");
        }
        if (GetAccountAge(AccountAge) < 12)
        {
            balance -= Math.Round(amount + (amount * interestRate), 2);
            Console.WriteLine($"Interest removed as Account Age is {GetAccountAge(AccountAge)} months old");
        }
        else
        {
            balance -= amount;
        }
            ;
    }

    public decimal GetBalance()
    {
        return Math.Round(balance + (balance * interestRate), 2);
    }

    public string GetCustomerId()
    {
        return CustomerId;
    }

}
