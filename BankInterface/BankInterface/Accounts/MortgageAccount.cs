using BankInterface.Interface;

namespace BankInterface.Accounts;

internal class MortgageAccount : IBankAccount
{
    private decimal remainingBalance = 12563;
    private decimal amountPaid = 938;
    private string CustomerId;
    private DateTime AccountAge;

    public MortgageAccount(string Id, DateTime Age)
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
        remainingBalance -=  amount;
        amountPaid += amount;
    }

    public decimal GetBalance()
    {
        GetBalances();
        return remainingBalance;
    }

    public (decimal PaidBalance, decimal OutstandingBalance) GetBalances()
    {
        //Console.WriteLine($"Mortgage Account \n------------------------ \nOutstanding: {remainingBalance}\nPaid Balance: {amountPaid}\n");
        return (remainingBalance, amountPaid);
    }

    public void WithdrawMoney(decimal amount)
    {
        Console.WriteLine("Withdrawls can't be made on mortgage accounts");
    }

    public string GetCustomerId()
    {
        return CustomerId;
    }
}
