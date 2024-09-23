namespace Labaratorna3OOP;

public class Payment
{
    public void PaymentMethod(PaymentProcessor processor, decimal amount)
    {
        processor.Pay(amount);
    }
}