using Lab10OOP.Entity;
using Lab10OOP.Manager.Interfaces;

namespace Lab10OOP.Manager.Services;

public class EmailNotifiactionService : INotificationService
{
    private ILoggerManager LoggerManager;

    public EmailNotifiactionService(ILoggerManager logger)
    {
        LoggerManager = logger;
    }
    public bool NotifyUser(User user, string message)
    {
        if (user == null || string.IsNullOrEmpty(message))
        {
            LoggerManager.AddLogger("Invalid input");
            return false;
        }
        LoggerManager.AddLogger($"User with {user.Email} notified with message: {message}");
        return true;
    }
}