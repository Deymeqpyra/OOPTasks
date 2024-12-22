using Application.Abstraction.Interfaces;

namespace Application.Implementation.Services;

public class FileLogger :  ILogger
{
    private string _filePath;

    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }
    
    public string InfoMessage(string message)
    {
        string infoMessage = $"[{DateTime.UtcNow}] [FILE] INFO: {message}; ";
        using (var writer = new StreamWriter(_filePath, true))
        {
            writer.WriteLine(infoMessage);
        }
        return infoMessage;
    }

    public string ErrorMessage(string message, string className)
    {
        string errorMessage = $"[{DateTime.UtcNow}] [FILE] ERROR: {message}; \n LOCATION: {className};";
        using (var writer = new StreamWriter(_filePath, true))
        {
            writer.WriteLine(errorMessage);
        }
        return errorMessage;
    }

    public string WarnMessage(string message)
    {
        string warnMessage = $"[{DateTime.UtcNow}] [FILE] WARN: {message};";
        using (var writer = new StreamWriter(_filePath, true))
        {
            writer.WriteLine(warnMessage);
        }
        return warnMessage;
    }
}