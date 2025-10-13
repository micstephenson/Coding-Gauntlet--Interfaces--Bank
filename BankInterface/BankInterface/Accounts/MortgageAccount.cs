using BankInterface.Interface;

namespace BankInterface.Accounts;

internal class MortgageAccount : IBankAccount
{
    private decimal remainingBalance;
    private decimal amountPaid;
    private string CustomerId;

    public MortgageAccount()
    {
        CustomerId = (new Random().Next(100000, 999999)).ToString();
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
        throw new NotImplementedException();
    }

    public string GetCustomerId()
    {
        return CustomerId;
    }
}
