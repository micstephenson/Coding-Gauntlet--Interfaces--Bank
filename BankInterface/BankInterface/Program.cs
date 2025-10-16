using BankInterface.AccountFunctions;
using BankInterface.CreatingAccounts;
using BankInterface.Interface;

class Program
{
    static void Main(string[] args)
    {
        var accountsCreator = new CreateAccounts();
        List<IBankAccount> accounts = accountsCreator.CreateAccount();

        while (true)
        {
            var accountChecker = new CheckAccounts(accounts);
            Console.Title = "Bank Menu";
            Console.WriteLine("Welcome To The Bank Menu");
            Console.WriteLine("-------------------------");
            Console.WriteLine("What would you like to access?\n");
            Console.WriteLine("[1] Create A New Account");
            Console.WriteLine("[2] Show Accounts");
            Console.WriteLine("[3] Select An Existing Account");
            Console.WriteLine("[4] Exit");
            Console.Write("\nYour Choice: ");

                        
            string? inputStr = Console.ReadLine();
            Console.WriteLine();
            if (!int.TryParse(inputStr, out int input))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                DelayedClearPage();
                continue;
            }

            switch (input)
            {                
                case 1:
                    Console.Clear();
                    Console.WriteLine("*Create New Account*");
                    Console.WriteLine("What Type of Account would you like to Create?\n");
                    Console.WriteLine("[1] Current Account\n[2] Savings Account\n[3] Mortgage Account\n");
                    Console.Write("Your Choice: ");

                    string? AccountType = Console.ReadLine();
                    Console.WriteLine("");
                    if (!int.TryParse(AccountType, out int UserAccountType))
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        DelayedClearPage();
                        continue;
                    }

                    Console.Write("Customer Id: ");
                    string? CustomerId = Console.ReadLine();
                    Console.Write("Account Creation Date (yyyy-mm-dd): ");
                    string? AccountCreation = Console.ReadLine();
                    if (!DateTime.TryParse(AccountCreation, out DateTime accountCreationDate))
                    {                        
                        Console.WriteLine("Invalid date format. Please enter a valid date (e.g., 2024-06-10).");                        
                        DelayedClearPage();                        
                    }
                    else
                    {
                    // ------------------------------------------------------------------------------------------------------------------------------------------------
                        switch (UserAccountType)
                        {
                            case 1:
                                accountsCreator.UserCreatedAccount("CurrentAccount", CustomerId, accountCreationDate);
                                break;
                            case 2:
                                accountsCreator.UserCreatedAccount("SavingsAccount", CustomerId, accountCreationDate);
                                break;
                            case 3:
                                accountsCreator.UserCreatedAccount("MortgageAccount", CustomerId, accountCreationDate);
                                break;
                        }
                    }
                    
                    break;                                    

                case 2:
                    var displayAccounts = new DisplayAccounts(accounts);
                    Console.WriteLine("\n                        ACCOUNTS:\n");
                    displayAccounts.ShowAccounts();
                    Console.WriteLine("Press Enter to return to menu...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 3:
                    Console.WriteLine("Enter Customer ID:");
                    string? ChosenAccountId = Console.ReadLine();
                    Console.Clear();

                    IBankAccount? selectedAccount = accountChecker.CheckUserIdAccounts(ChosenAccountId);

                    if (selectedAccount == null)
                    {
                        Console.WriteLine("No account found with that Customer ID.");
                        DelayedClearPage();
                        break;                        
                    }
                    
                    else
                    {
                        // ----------------------------------------------------------------------------------------------------------------------------------------------------
                        while (true)
                        {
                            Console.Title = "User Menu";
                            Console.WriteLine($"Customer {selectedAccount.GetCustomerId()} - {selectedAccount.GetType().Name}");
                            Console.WriteLine($"---------------------------------------------");
                            Console.WriteLine("What would you like to do?\n");
                            Console.WriteLine("[1] Read Balance");
                            Console.WriteLine("[2] Deposit");
                            Console.WriteLine("[3] Withdraw");
                            Console.WriteLine("[4] Exit");
                            Console.Write("\nYour Choice: ");

                            string? inputStr2 = Console.ReadLine();
                            Console.WriteLine("");
                            decimal OriginalBalance = selectedAccount.GetBalance();
                            if (!int.TryParse(inputStr2, out int input2))
                            {
                                Console.WriteLine("Invalid input. Please enter a number.");
                                DelayedClearPage();
                                continue;
                            }
                            // --------------------------------------------------------------------------------------------------------------------------------------------------
                            switch (input2)
                            {
                                case 1:
                                    Console.WriteLine($"Balance: £{selectedAccount.GetBalance()}");
                                    Console.WriteLine("Press Enter to return to account menu...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case 2:
                                    Console.Write("How much would you like to deposit?\nDeposit: £");

                                    string? deposit = Console.ReadLine();
                                    if (decimal.TryParse(deposit, out decimal depositAmount))
                                    {
                                        selectedAccount.AddMoney(depositAmount);
                                        Console.WriteLine($"Deposited amount: {depositAmount}\nOld Balance: {OriginalBalance}\nNew Balance: {selectedAccount.GetBalance()}\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid amount");
                                    }
                                    Console.WriteLine("Press Enter to return to account menu...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case 3:
                                    Console.Write("How much would you like to withdraw?\nWithdraw: £");
                                    string? withdraw = Console.ReadLine();
                                    if (decimal.TryParse(withdraw, out decimal withdrawAmount))
                                    {
                                        selectedAccount.WithdrawMoney(withdrawAmount);
                                        Console.WriteLine($"Withdrawn amount: {withdrawAmount}\nOld Balance: {OriginalBalance}\nNew Balance: {selectedAccount.GetBalance()}\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid amount");
                                    }
                                    Console.WriteLine("Press Enter to return to account menu...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case 4:
                                    // Exit user menu and return to main bank menu
                                    Console.Clear();
                                    goto EndUserMenu;

                                default:
                                    Console.WriteLine("Invalid option. Try again.");
                                    DelayedClearPage();
                                    break;
                            }
                        }
                    EndUserMenu:
                        break;
                    }
                // --------------------------------------------------------------------------------------------------------------------------------------------------------------
                case 4:                    
                    Console.WriteLine("\n*Goodbye*");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Environment.Exit(1);
                    break;

                default:                                 
                    Console.WriteLine("Invalid option. Try again.");
                    DelayedClearPage();
                    break;
            }
        }
    }

    public static void DelayedClearPage()
    {
        Thread.Sleep(1000);
        Console.Clear();
    }
}