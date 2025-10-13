using BankInterface.Interface;

namespace BankInterface.Accounts;

internal class SavingsAccount : IBankAccount
{
    private decimal balance;
    private const decimal interestRate = 0.03m;
    private string CustomerId;
    private int AccountAge;

    public SavingsAccount()
    {
        CustomerId = new Random().Next(100000, 999999).ToString();
        AccountAge = new Random().Next(1, 30);
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
        if (AccountAge < 12)
        {
            balance -= Math.Round(amount * interestRate, 2);
            Math.Round(balance, 2);
            Console.WriteLine($"Interest removed as Account Age is {AccountAge}");
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
