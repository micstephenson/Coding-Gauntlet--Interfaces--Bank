using BankInterface.Accounts;
using BankInterface.Interface;
using System.Security.Principal;

namespace BankInterface.CreatingAccounts;

internal class CreateAccounts
{
    List<IBankAccount> accounts = new List<IBankAccount>();

    DateTime DateOne = new DateTime(2021, 10, 23);
    DateTime DateTwo = new DateTime(2025, 03, 12);
    DateTime DateThree = new DateTime(2015, 07, 07);
    DateTime DateFour = new DateTime(2025, 01, 29);
    DateTime DateFive = new DateTime(2019, 09, 02);

    CurrentAccount Currentaccount1;
    CurrentAccount Currentaccount2;
    SavingsAccount Savingsaccount1;
    SavingsAccount Savingsaccount2;
    MortgageAccount Mortgageaccount1;

    public List<IBankAccount> CreateAccount() //rename
    {
        Currentaccount1 = new CurrentAccount("111", DateOne);
        Currentaccount2 = new CurrentAccount("222", DateTwo);
        Savingsaccount1 = new SavingsAccount("333", DateThree);
        Savingsaccount2 = new SavingsAccount("444", DateFour);
        Mortgageaccount1 = new MortgageAccount("555", DateFive);

        accounts.Add(Currentaccount1);
        accounts.Add(Currentaccount2);
        accounts.Add(Savingsaccount1);
        accounts.Add(Savingsaccount2);
        accounts.Add(Mortgageaccount1);

        foreach (var account in accounts)
        {
            decimal amount = new Random().Next(100, 5000);
            account.AddMoney(amount);
        }

        return accounts;
    }

    public void UserCreatedAccount(string AccountType, string CustomerId, DateTime AccountCreation)
    {
        if (AccountType == "CurrentAccount")
        {
            foreach (var account in accounts)
            {
                if ((CustomerId == account.GetCustomerId()) && (account.GetType().Name == "CurrentAccount"))
                {
                    Console.WriteLine("You already have a Current Account");
                }
                else
                {
                    accounts.Add(new CurrentAccount(CustomerId, AccountCreation));
                    Console.WriteLine("\n*Account Created*");
                    Thread.Sleep(1000);
                    Console.WriteLine("*Returning To Main Menu*");
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
                }
            }
            
        }
        else if (AccountType == "SavingsAccount")
        {
            foreach (var account in accounts)
            {
                if ((CustomerId == account.GetCustomerId()) && (account.GetType().Name == "SavingsAccount"))
                {
                    Console.WriteLine("You already have a Savings Account");
                }
                else
                {
                    accounts.Add(new SavingsAccount(CustomerId, AccountCreation));
                    Console.WriteLine("\n*Account Created*");
                    Thread.Sleep(1000);
                    Console.WriteLine("*Returning To Main Menu*");
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
                }
            }
        }
        else if (AccountType == "MortgageAccount")
        {
            foreach (var account in accounts)
            {
                if ((CustomerId == account.GetCustomerId()) && (account.GetType().Name == "MortgageAccount"))
                {
                    Console.WriteLine("You already have a Mortgage Account");
                }
                else
                {
                    accounts.Add(new MortgageAccount(CustomerId, AccountCreation));
                    Console.WriteLine("\n*Account Created*");
                    Thread.Sleep(1000);
                    Console.WriteLine("*Returning To Main Menu*");
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
                }
            }
        }
    }

}
