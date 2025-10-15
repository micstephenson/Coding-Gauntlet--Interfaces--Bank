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
            if (account.GetType().Name == "CurrentAccount")
            {
                Console.WriteLine($"Current Account: {account.GetCustomerId()}\n");
            }
            else if (account.GetType().Name == "SavingsAccount")
            {
                Console.WriteLine($"Savings Account: {account.GetCustomerId()}\n");
            }
            else if (account.GetType().Name == "MortgageAccount")
            {
                Console.WriteLine($"Mortgage Account: {account.GetCustomerId()}\n");
            }
        }
    }
}
