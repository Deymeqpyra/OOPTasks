using StatePattern.Interfaces;

namespace StatePattern.State;

public class DeliveredOrderState : IOrderState
{
    public void Handle(OrderContext context)
    {
        Console.WriteLine("Замовлення вже доставлено!");
    }

    public string GetStateName() => "Доставлений";
}