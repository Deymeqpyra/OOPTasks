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
        string infoMessage = $"[FILE] INFO: {message}; DATE UTC: {DateTime.UtcNow}";
        using (var writer = new StreamWriter(_filePath, true))
        {
            writer.WriteLine(infoMessage);
        }
        return infoMessage;
    }

    public string ErrorMessage(string message)
    {
        string errorMessage = $"[FILE] ERROR: {message}; DATE UTC: {DateTime.UtcNow}";
        using (var writer = new StreamWriter(_filePath, true))
        {
            writer.WriteLine(errorMessage);
        }
        return errorMessage;
    }

    public string WarnMessage(string message)
    {
        string warnMessage = $"[FILE] WARN: {message}; DATE UTC: {DateTime.UtcNow}";
        using (var writer = new StreamWriter(_filePath, true))
        {
            writer.WriteLine(warnMessage);
        }
        return warnMessage;
    }
}