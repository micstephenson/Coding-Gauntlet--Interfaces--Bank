using BankInterface.CreatingAccounts;
using BankInterface.Interface;

class Program
{
    static void Main(string[] args)
    {
        var accountsCreator = new CreateAccounts();
        List<IBankAccount> accounts = [];
        bool showCreateAccounts = true;

        while (true)
        {
            Console.Title = "Bank Menu";
            Console.WriteLine("Welcome To The Bank Menu");
            Console.WriteLine("-------------------------");
            Console.WriteLine("What would you like to access?");
            Console.WriteLine("");

            if (showCreateAccounts)
                Console.WriteLine("[1] Create Accounts");
            else
                Console.WriteLine("[2] Show Accounts");
            Console.WriteLine("[3] Select An Existing Account");
            Console.WriteLine("[4] Exit");
            Console.Write("Your Choice: ");

            string? inputStr = Console.ReadLine();
            if (!int.TryParse(inputStr, out int input))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                Thread.Sleep(1000);
                Console.Clear();
                continue;
            }

            // Adjust input if "Create Accounts" is hidden
            if (!showCreateAccounts && input == 1)
            {
                Console.WriteLine("Invalid option. Try again.");
                Thread.Sleep(1000);
                Console.Clear();
                continue;
            }

            switch (input)
            {
                case 1:
                    if (showCreateAccounts)
                    {
                        accounts = accountsCreator.CreateAccount();
                        Console.WriteLine("*Accounts Created*");
                        Thread.Sleep(1000);
                        Console.WriteLine("*Returning To Main Menu*");
                        Thread.Sleep(1500);
                        Console.Clear();
                        showCreateAccounts = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Try again.");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    break;

                case 2:
                    var displayAccounts = new DisplayAccounts(accounts);
                    Console.WriteLine("\n        ACCOUNTS:");
                    displayAccounts.ShowAccounts();
                    Console.WriteLine("Press Enter to return to menu...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 3:
                    Console.WriteLine("Enter Customer ID:");
                    string? ChosenAccountId = Console.ReadLine();
                    Console.Clear();

                    IBankAccount? selectedAccount = accounts.FirstOrDefault(account => account.GetCustomerId() == ChosenAccountId);

                    if (selectedAccount == null)
                    {
                        Console.WriteLine("No account found with that Customer ID.");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                    }
                    else
                    {
// --------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                        while (true)
                        {
                            Console.Title = "User Menu";
                            Console.WriteLine($"Account {selectedAccount.GetCustomerId()}");
                            Console.WriteLine($"---------------------------------------------");
                            Console.WriteLine("What would you like to do?");
                            Console.WriteLine("");
                            Console.WriteLine("[1] Read Balance");
                            Console.WriteLine("[2] Deposit");
                            Console.WriteLine("[3] Withdraw");
                            Console.WriteLine("[4] Exit \n");

                            string? inputStr2 = Console.ReadLine();
                            if (!int.TryParse(inputStr2, out int input2))
                            {
                                Console.WriteLine("Invalid input. Please enter a number.");
                                Thread.Sleep(1000);
                                Console.Clear();
                                continue;
                            }
                            // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                            switch (input2)
                            {
                                case 1:
                                    Console.WriteLine($"Balance: {selectedAccount.GetBalance()}");
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
                                        Console.WriteLine($"Deposited amount: {depositAmount}\nNew Balance: {selectedAccount.GetBalance()}\n");
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
                                        Console.WriteLine($"Withdrawn amount: {withdrawAmount}\nNew Balance: {selectedAccount.GetBalance()}\n");                                        
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
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    break;
                            }
                        }
                        EndUserMenu:
                        break;
                    }
                // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                case 4:                    
                    Console.WriteLine("goodbye");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;

                default:                                 
                    Console.WriteLine("Invalid option. Try again.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
            }
        }
    }
}