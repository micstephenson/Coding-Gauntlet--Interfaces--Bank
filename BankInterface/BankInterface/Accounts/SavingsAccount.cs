using BankInterface.Interface;

namespace BankInterface.Accounts;

internal class SavingsAccount : IBankAccount
{
    private decimal balance;
    private const decimal interestRate = 0.03m;
    private string CustomerId;
    private DateTime AccountAge = RandomDate();
    

    public SavingsAccount()
    {
        CustomerId = new Random().Next(100000, 999999).ToString();
    }

    public static DateTime RandomDate()
    {
        DateTime start = new DateTime(2010, 1, 1);
        int range = (DateTime.Today - start).Days;
        return start.AddDays(new Random().Next(range));
    }

    public double GetAccountAge(DateTime AccountAge)
    {
        double years = (DateTime.Today - AccountAge).TotalDays / 365.25;
        years = years == 0 ? 0 : Math.Round(years, 0 - (int)Math.Floor(Math.Log10(Math.Abs(years))));
        return years;
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
        if ((DateTime.Today - AccountAge).TotalDays / 365.25 < 12)
        {
            balance -= Math.Round(amount * interestRate, 2);
            Math.Round(balance, 2);
            Console.WriteLine($"Interest removed as Account Age is {GetAccountAge(AccountAge)}");
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
