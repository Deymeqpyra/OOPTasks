using Application.Abstraction.Interfaces;

namespace Application.Implementation.Services;

public class ConsoleLogger  : ILogger
{
    public string InfoMessage(string message)
    {
        string infoMessage = $"[{DateTime.UtcNow}] [CONSOLE] INFO: {message};";
        Console.WriteLine(infoMessage);
        return infoMessage;
    }

    public string ErrorMessage(string message, string className)
    {
        string errorMessage = $"[{DateTime.UtcNow}] [CONSOLE] ERROR: {message}; \n LOCATION: {className};";
        Console.WriteLine(errorMessage);
        return errorMessage;
    }

    public string WarnMessage(string message)
    {
        string warnMessage = $"[{DateTime.UtcNow}] [CONSOLE] WARN: {message};";
        Console.WriteLine(warnMessage);
        return warnMessage;
    }
}