using Application.Abstraction.Interfaces;
using Application.Implementation.Services;

namespace Application.Implementation.Factory;

public class ConsoleLoggerFactory  : ILoggerFactory
{
    public ILogger CreateLogger()
    {
        return new ConsoleLogger();
    }
}