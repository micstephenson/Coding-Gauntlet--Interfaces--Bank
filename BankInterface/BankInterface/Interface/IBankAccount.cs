namespace BankInterface.Interface;

public interface IBankAccount
{
    void AddMoney(decimal amount);
    void WithdrawMoney(decimal amount);
    decimal GetBalance();
    string GetCustomerId();
}
