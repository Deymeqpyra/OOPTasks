using Lab10OOP.Entity;

namespace Lab10OOP.Manager.Interfaces;

public interface INotificationService
{
    bool NotifyUser(User user, string message);
}