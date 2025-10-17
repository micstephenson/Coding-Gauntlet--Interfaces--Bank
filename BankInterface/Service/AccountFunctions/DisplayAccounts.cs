using BankInterface.Data.Interface;
using System.Text;

namespace BankInterface.Service.CreatingAccounts;

public class DisplayAccounts
{
    private List<IBankAccount> accounts;

    public DisplayAccounts(List<IBankAccount> accounts)
    {
        this.accounts = accounts;
    }

    public void ShowAccounts()
    {
        List<string> accountTypes = new List<string>
        {
            "CurrentAccount",
            "SavingsAccount",
            "MortgageAccount"
        };
        foreach (var accountType in accountTypes)
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine($"                    {AddSpaceBeforeUppercase(accountType)}s");
            Console.WriteLine("------------------------------------------------------------");
            foreach (var account in accounts)
            {
                if (account.GetType().Name == $"{accountType}")
                {
                    Console.WriteLine($"{accountType}: {account.GetCustomerId()}");
                }
            }
            Console.WriteLine("\n\n");
        }      
    }

    public static string AddSpaceBeforeUppercase(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        var result = new StringBuilder();
        foreach (char c in input)
        {
            if (char.IsUpper(c) && result.Length > 0)
                result.Append(' ');
            result.Append(c);
        }
        return result.ToString();
    }
}
