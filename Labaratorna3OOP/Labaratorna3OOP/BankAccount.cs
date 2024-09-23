namespace Labaratorna3OOP;

public class BankAccount : PaymentProcessor
{
    public override void Pay(decimal amount)
    {
        Console.WriteLine($"You have paid by BankAccount : ${amount}");
    }

}