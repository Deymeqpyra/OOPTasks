using StatePattern.Interfaces;

namespace StatePattern;

public class OrderContext
{
    private IOrderState _state;

    public OrderContext(IOrderState initialState)
    {
        _state = initialState;
    }

    public void SetState(IOrderState state)
    {
        _state = state;
    }

    public void ProcessOrder()
    {
        _state.Handle(this);
    }

    public string GetCurrentState()
    {
        return _state.GetStateName();
    }
}