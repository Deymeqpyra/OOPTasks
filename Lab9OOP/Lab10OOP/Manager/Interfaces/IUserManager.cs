using Lab10OOP.Entity;

namespace Lab10OOP.Manager.Interfaces;

public interface IUserManager
{
    bool AddUser(User user);
    bool EditUser(string email, User user);
    bool DeleteUser(string email);
    List<User> GetAllUsers();
}