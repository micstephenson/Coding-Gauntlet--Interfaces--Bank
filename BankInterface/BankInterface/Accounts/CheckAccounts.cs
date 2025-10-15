using BankInterface.Interface;

namespace BankInterface.Accounts;

internal class CheckAccounts
{
    private List<IBankAccount> accounts;

    public CheckAccounts(List<IBankAccount> accounts)
    {
        this.accounts = accounts;
    }
    public IBankAccount CheckUserIdAccounts(string customerId)
    {
        var accountsForCustomer = accounts
            .Where(a => a.GetCustomerId() == customerId)
            .ToList();

        var accountTypes = accountsForCustomer
            .Select(a => a.GetType().Name)
            .Distinct()
            .ToList();

        if (accountTypes.Count > 1)
        {
            Console.WriteLine($"Customer ID '{customerId}' is associated with multiple account types: {string.Join(", ", accountTypes)}");
            Console.WriteLine("Which Account would you like to access?");
            for (int i = 0; i < accountTypes.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {accountTypes[i]}");
            }
            Console.WriteLine("");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int chosenIndex) && chosenIndex >= 1 && chosenIndex <= accountTypes.Count)
            {
                string chosenType = accountTypes[chosenIndex - 1];
                IBankAccount? selectedAccount = accountsForCustomer.FirstOrDefault(account => account.GetType().Name == chosenType);
                Console.Clear();
                Console.WriteLine($"{chosenType}");
                return selectedAccount!;
            }
            else
            {
                Console.WriteLine("Invalid selection.");
                return null!;
            }
        }
        else if (accountTypes.Count == 1)
        {
            IBankAccount? selectedAccount = accountsForCustomer.FirstOrDefault();
            return selectedAccount!;
        }
        return null!;
    }
}

