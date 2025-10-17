using BankInterface.Data.Interface;

namespace BankInterface.Accounts;

public class CurrentAccount : IBankAccount
{
    private decimal balance;
    private string CustomerId;
    private DateTime AccountAge;

    public CurrentAccount(string Id, DateTime Age)
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
        else
        {
            balance -= amount;
        }
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
