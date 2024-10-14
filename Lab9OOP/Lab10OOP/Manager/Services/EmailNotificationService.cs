using Lab10OOP.Entity;
using Lab10OOP.Manager.Interfaces;

namespace Lab10OOP.Manager.Services;

public class EmailNotificationService : INotificationService
{
    private ILoggerManager LoggerManager;

    public EmailNotificationService(ILoggerManager logger)
    {
        LoggerManager = logger;
    }
    public bool NotifyUser(User user, string message)
    {
        if (user.Email == null || string.IsNullOrEmpty(message))
        {
            LoggerManager.ErrorLogger("Invalid input");
            return false;
        }
        LoggerManager.InfoLogger($"User with {user.Email} notified with message: {message} at {DateTime.Now}");
        return true;
    }
}