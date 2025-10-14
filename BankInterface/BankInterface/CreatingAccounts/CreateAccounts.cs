using BankInterface.Accounts;
using BankInterface.Interface;

namespace BankInterface.CreatingAccounts;

internal class CreateAccounts
{
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
        List<IBankAccount> accounts = new List<IBankAccount>();

        Currentaccount1 = new CurrentAccount("111", DateOne);
        Currentaccount2 = new CurrentAccount("9371836", DateTwo);
        Savingsaccount1 = new SavingsAccount("9187324", DateThree);
        Savingsaccount2 = new SavingsAccount("1273834", DateFour);
        Mortgageaccount1 = new MortgageAccount("4282312", DateFive);

        accounts.Add(Currentaccount1);
        accounts.Add(Currentaccount2);
        accounts.Add(Savingsaccount1);
        accounts.Add(Savingsaccount2);
        accounts.Add(Mortgageaccount1);

        return accounts;
    }

}
