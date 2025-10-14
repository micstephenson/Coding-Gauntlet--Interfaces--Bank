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
            throw new ArgumentException("Amount must be positive.");
        }
        balance += amount;
    }

    public void WithdrawMoney(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be positive.");
        }
        if (amount > balance)
        {
            throw new InvalidOperationException("Insufficient funds.");
        }
        if (GetAccountAge(AccountAge) < 12)
        {
            balance -= Math.Round(amount * interestRate, 2);
            Math.Round(balance, 2);
            Console.WriteLine($"Interest removed as Account Age is {GetAccountAge(AccountAge)} months old");
        }
        balance -= amount;
    }

    public decimal GetBalance()
    {
        return balance + (balance * interestRate);
    }

    public string GetCustomerId()
    {
        return CustomerId;
    }

}
