using BankInterface.Interface;

namespace BankInterface.Accounts;

internal class CurrentAccount : IBankAccount
{
    private decimal balance;
    private string CustomerId;

    public CurrentAccount()
    {
        CustomerId = (new Random().Next(100000, 999999)).ToString();
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
