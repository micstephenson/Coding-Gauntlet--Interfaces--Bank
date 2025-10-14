using BankInterface.CreatingAccounts;
using BankInterface.Interface;

class Program
{
    static void Main(string[] args)
    {
        var accountsCreator = new CreateAccounts();
        List<IBankAccount> accounts = [];

        while (true)
        {
            Console.Title = "Bank Menu";
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("");
            Console.WriteLine("[1] Create Accounts");
            Console.WriteLine("[2] Show Accounts");
            Console.WriteLine("[3] Exit");

            string input = Console.ReadLine();
            if (input == "1")
            {
                accounts = accountsCreator.CreateAccount();
                Console.WriteLine("*Accounts Created*");
                Thread.Sleep(1500);
                Console.Clear();
            }
            else if (input == "2")
            {
                var displayAccounts = new DisplayAccounts(accounts);
                displayAccounts.ShowAccounts();
                Console.WriteLine("Press Enter to return to menu...");
                Console.ReadLine();
                Console.Clear();
            }
            else if (input == "3")
            {
                Console.WriteLine("goodbye");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid option. Try again.");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}