using Application.Abstraction.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Application.Implementation.Factory;

public static class LoggerFactoryProvider
{
    public static ILoggerFactory GetFactory(IConfiguration configuration)
    {
        var loggerType = configuration["Logging:LoggerType"];

        if (loggerType == "Console")
        {
            return new ConsoleLoggerFactory();
        }
        if (loggerType == "File")
        {
            var filePath = configuration["Logging:FileLogger:FilePath"];
            return new FileLoggerFactory(filePath);
        }

        throw new InvalidOperationException("Invalid LoggerType in configuration.");
    }
}