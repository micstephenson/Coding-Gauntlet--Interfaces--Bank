using BankInterface.Interface;

namespace BankInterface.Accounts;

internal class MortgageAccount : IBankAccount
{
    private string CustomerId;

    public MortgageAccount()
    {
        CustomerId = (new Random().Next(100000, 999999)).ToString();
    }
    public void AddMoney(decimal amount)
    {
        throw new NotImplementedException();
    }

    public decimal GetBalance()
    {
        throw new NotImplementedException();
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
