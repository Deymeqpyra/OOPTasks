namespace StatePattern.Interfaces;

public interface IOrderState
{
    void Handle(OrderContext context);
    string GetStateName();
}