using Lab10OOP.Manager.Interfaces;

namespace Lab10OOP.Manager;

public class LoggerManager : ILoggerManager
{
    private List<string> _loggerList;

    public LoggerManager()
    {
        _loggerList = new List<string>();
    }
    public void InfoLogger(string log)
    {
       _loggerList.Add($"INFO: {log}");
    }
    public void ErrorLogger(string log)
    {
        _loggerList.Add($"ERROR: {log}"); 
    }

    public void ShowLog()
    {
        foreach (var log in _loggerList)
        {
            Console.WriteLine(log);
        }
    }
}