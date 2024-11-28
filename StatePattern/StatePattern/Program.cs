using StatePattern;
using StatePattern.State;


var order = new OrderContext(new NewOrderState());

Console.WriteLine($"Поточний стан: {order.GetCurrentState()}");
order.ProcessOrder();

Console.WriteLine($"Поточний стан: {order.GetCurrentState()}");
order.ProcessOrder();

Console.WriteLine($"Поточний стан: {order.GetCurrentState()}");
order.ProcessOrder();