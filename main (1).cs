using System;

// Интерфейс для банковского счета
public interface IAccount
{
    string AccountNumber { get; set; }
    double Balance { get; set; }

    void Deposit(double amount);
    void Withdraw(double amount);
    void DisplayAccountInfo();
}

// Класс для банковского счета
public class BankAccount : IAccount
{
    public string AccountNumber { get; set; }
    public double Balance { get; set; }

    public BankAccount(string accountNumber)
    {
        AccountNumber = accountNumber;
        Balance = 0;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (Balance - amount < 0)
        {
            Console.WriteLine("Недостаточно средств на счете");
        }
        else
        {
            Balance -= amount;
        }
    }

    public void DisplayAccountInfo()
    {
        Console.WriteLine($"Счет: {AccountNumber}, Баланс: {Balance}");
    }
}

// Интерфейс для управления банковскими счетами
public interface IAccountManager
{
    void OpenAccount(string accountNumber);
    void CloseAccount(string accountNumber);
    void Deposit(string accountNumber, double amount);
    void Withdraw(string accountNumber, double amount);
}

// Класс для управления банковскими счетами
public class AccountManager : IAccountManager
{
    public void OpenAccount(string accountNumber)
    {
        BankAccount account = new BankAccount(accountNumber);
        Console.WriteLine($"Открыт новый счет: {accountNumber}");
    }

    public void CloseAccount(string accountNumber)
    {
        Console.WriteLine($"Счет {accountNumber} закрыт");
    }

    public void Deposit(string accountNumber, double amount)
    {
        // реализация пополнения счета
    }

    public void Withdraw(string accountNumber, double amount)
    {
        // реализация снятия средств со счета
    }
}

class Program
{
    static void Main()
    {
        AccountManager accountManager = new AccountManager();

        accountManager.OpenAccount("12345");
        accountManager.OpenAccount("54321");

        accountManager.CloseAccount("54321");

        Console.ReadKey();
    }
}