using Application.Abstraction.Interfaces;

namespace Application.Implementation.Services;

public class ConsoleLogger  : ILogger
{
    public string InfoMessage(string message)
    {
        string infoMessage = $"[CONSOLE] INFO: {message}; DATE UTC: {DateTime.UtcNow}";
        Console.WriteLine(infoMessage);
        return infoMessage;
    }

    public string ErrorMessage(string message)
    {
        string errorMessage = $"[CONSOLE] ERROR: {message}; DATE UTC: {DateTime.UtcNow}";
        Console.WriteLine(errorMessage);
        return errorMessage;
    }

    public string WarnMessage(string message)
    {
        string warnMessage = $"[CONSOLE] WARN: {message}; DATE UTC: {DateTime.UtcNow}";
        Console.WriteLine(warnMessage);
        return warnMessage;
    }
}