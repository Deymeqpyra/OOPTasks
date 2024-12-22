namespace Application.Abstraction.Interfaces;

public interface ILoggerFactory
{
    ILogger CreateLogger();
}