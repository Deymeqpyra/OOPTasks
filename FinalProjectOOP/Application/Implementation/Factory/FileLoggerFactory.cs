using Application.Abstraction.Interfaces;
using Application.Implementation.Services;

namespace Application.Implementation.Factory;

public class FileLoggerFactory : ILoggerFactory
{
    private readonly string _filePath;

    public FileLoggerFactory(string filePath)
    {
        _filePath = filePath;
    }

    public ILogger CreateLogger()
    {
        return new FileLogger(_filePath);
    }
}