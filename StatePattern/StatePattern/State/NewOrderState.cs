using StatePattern.Interfaces;

namespace StatePattern.State;

public class NewOrderState : IOrderState
{
    public void Handle(OrderContext context)
    {
        Console.WriteLine("Замовлення обробляється...");
        context.SetState(new ProcessedOrderState());
    }

    public string GetStateName() => "Новий";
}