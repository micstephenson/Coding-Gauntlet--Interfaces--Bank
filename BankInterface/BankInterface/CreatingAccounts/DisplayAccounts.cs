using BankInterface.Interface;

namespace BankInterface.CreatingAccounts;

internal class DisplayAccounts
{
    private List<IBankAccount> accounts;

    public DisplayAccounts(List<IBankAccount> accounts)
    {
        this.accounts = accounts;
    }

    public void ShowAccounts()
    {
        foreach (var account in accounts)
        {
            decimal amount = new Random().Next(100, 1000);
            account.AddMoney(amount);
            Console.WriteLine($"Account: {account.GetCustomerId()}");

            if (account.GetType().Name == "MortgageAccount")
            {
                Console.WriteLine($"Mortgage Account Balance: {account.GetBalance()}\n");
            }
            else
            {
                Console.WriteLine($"Account Balance: {account.GetBalance()}");
                account.WithdrawMoney(100);
                Console.WriteLine($"Account Balance after withdrawl: {account.GetBalance()}\n");
            }
        }
    }
}
