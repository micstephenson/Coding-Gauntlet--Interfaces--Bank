using BankInterface.Interface;

namespace BankInterface.Accounts;

internal class SavingsAccount : IBankAccount
{
    private decimal balance;
    private const decimal interestRate = 0.03m;
    private string CustomerId;

    public SavingsAccount()
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
        return balance + (balance * interestRate);
    }

    public string GetCustomerId()
    {
        return CustomerId;
    }
}
