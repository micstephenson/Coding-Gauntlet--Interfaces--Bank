using BankInterface.Interface;

namespace BankInterface.Accounts;

internal class MortgageAccount : IBankAccount
{
    private decimal remainingBalance;
    private decimal amountPaid;
    private string CustomerId;
    private DateTime AccountAge = RandomDate();

    public MortgageAccount()
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
        remainingBalance -=  amount;
        amountPaid += amount;
    }

    public decimal GetBalance()
    {
        throw new NotImplementedException();
    }

    public (decimal PaidBalance, decimal OutstandingBalance) GetBalances()
    {
        Console.WriteLine($"Mortgage Account \n ------------------------ \nOutstanding: {remainingBalance} \n Paid Balance: {amountPaid}\n");
        return (remainingBalance, amountPaid);
    }

    public void WithdrawMoney(decimal amount)
    {
        throw new NotImplementedException("Withdrawls can't be made on mortgage accounts");
    }

    public string GetCustomerId()
    {
        return CustomerId;
    }
}
