namespace Lab10OOP.Manager.Interfaces;

public interface ILoggerManager
{
    void InfoLogger(string log);
    void ErrorLogger(string log);
    public void ShowLog();
}