namespace Application.Abstraction.Interfaces;

public interface ILogger
{
    string InfoMessage(string message);
    string ErrorMessage(string message);
    string WarnMessage(string message);
}