using BankInterface.Interface;

namespace BankInterface.Accounts;

internal class CurrentAccount : IBankAccount
{
    private decimal balance;
    private string CustomerId;
    private DateTime AccountAge = RandomDate();

    public CurrentAccount()
    {
        CustomerId = (new Random().Next(100000, 999999)).ToString();
    }

    public static DateTime RandomDate()
    {
        DateTime start = new DateTime(1920, 1, 1);
        int range = (DateTime.Today - start).Days;
        return start.AddDays(new Random().Next(range));
    }

    public double GetAccountAge(DateTime AccountAge)
    {
        var AccountCreationYear = (DateTime.Today - AccountAge).TotalDays;
        double CurrentYear = DateTime.Today.Year;
        return CurrentYear - AccountCreationYear;
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
        balance -= amount;
    }

    public decimal GetBalance()
    {
        return balance;
    }

    public string GetCustomerId()
    {
        return CustomerId;
    }
}
