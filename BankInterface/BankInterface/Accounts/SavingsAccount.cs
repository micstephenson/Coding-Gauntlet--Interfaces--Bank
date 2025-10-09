using BankInterface.Interface;

namespace BankInterface.Accounts;

internal class SavingsAccount : IBankAccount
{
    private decimal balance;
    private const decimal interestRate = 0.03m; 
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
}
