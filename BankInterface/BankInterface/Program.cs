using BankInterface.CreatingAccounts;
using BankInterface.Interface;

class Program
{
    static void Main(string[] args)
    {
        var accountsCreator = new CreateAccounts(); 
        List<IBankAccount> accounts = accountsCreator.CreateAccount();

        var displayAccounts = new DisplayAccounts(accounts); 
        displayAccounts.ShowAccounts();
    }
}