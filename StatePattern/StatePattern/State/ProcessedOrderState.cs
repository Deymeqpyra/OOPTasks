using StatePattern.Interfaces;

namespace StatePattern.State;

public class ProcessedOrderState : IOrderState
{
    public void Handle(OrderContext context)
    {
        Console.WriteLine("Замовлення доставляється...");
        context.SetState(new DeliveredOrderState());
    }

    public string GetStateName() => "Оброблений";
}