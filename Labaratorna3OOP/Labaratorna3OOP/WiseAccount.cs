namespace Labaratorna3OOP;

public class WiseAccount : PaymentProcessor
{
    public override void Pay(decimal amount)
    {
        Console.WriteLine($"You have paid by Wise account : ${amount}");
    }
}