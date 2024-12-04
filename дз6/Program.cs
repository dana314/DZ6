// Упражнение 7.1 Создать класс счет в банке с закрытыми полями: номер счета, баланс, тип банковского счета
// Упражнение 7.2 Изменить класс счет в банке из упражнения 7.1 чтобы номер счета генерировался сам и был уникальным
// Упражнение 7.3 Добавить в класс счет в банке два метода: снять со счета и положить на счет
using System;
public enum AccountType
{
    savings,
    actual,

}
public class BankAccount
{
    private static int nextAccount = 1; 
    private readonly int accountNumber; 
    private decimal balance; 
    private readonly AccountType accountType; 

    
    public BankAccount(AccountType accountType)
    {
        this.accountNumber = nextAccount++; 
        this.accountType = accountType;
        this.balance = 0; 
    }
    public int GetAccountNumber()
    {
        return accountNumber;
    }
    public decimal GetBalance()
    {
        return balance;
    }
    public AccountType GetAccountType()
    {
        return accountType;
    }
    public void Replenishment(decimal amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"внесено: {amount}. текущий баланс: {balance}");
        }
        else
        {
            Console.WriteLine("сумма пополнения должна быть > 0");
        }
    }
    public void Take0ff(decimal amount)
    {
        if (amount > balance)
        {
            Console.WriteLine("недостаточно средств");
        }
        else
        {
            balance -= amount;
            Console.WriteLine($"снято: {amount}. остаток: {balance}");
        }
    }
    public void Info()
    {
        Console.WriteLine($"номер счета: {accountNumber}, тип счета: {accountType}, баланс: {balance}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        BankAccount firstAccount = new BankAccount(AccountType.savings);
        firstAccount.Info();
        firstAccount.Replenishment(1000);
        firstAccount.Take0ff(200);
        firstAccount.Info();
        BankAccount secondAccount = new BankAccount(AccountType.actual);
        secondAccount.Info(); 
    }
}