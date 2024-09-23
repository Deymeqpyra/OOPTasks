namespace Labaratorna3OOP;

public class PayonnerAccount : PaymentProcessor
{
    public override void Pay(decimal amount)
    {
        Console.WriteLine($"Yoy have paid by Payonner account : ${amount}");
    }
}