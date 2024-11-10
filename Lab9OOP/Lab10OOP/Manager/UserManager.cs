using Lab10OOP.Entity;
using Lab10OOP.Manager.Interfaces;

namespace Lab10OOP.Manager;

public class UserManager : IUserManager
{
    // private ILoggerManager LoggerManager { get; set; }
    
    private List<User> ListOfUsers = new List<User>();
    
    // public UserManager(ILoggerManager loggerManager)
    // {
    //     LoggerManager = loggerManager;
    // }

    public List<User> GetAllUsers()
    {
        return ListOfUsers;
    }
    public bool AddUser(User user)
    {
        if (ListOfUsers.Any(x => x.Email == user.Email))
        {
            // LoggerManager.AddLogger("User already exists with this email");
            return false;
        }
        ListOfUsers.Add(user);
        // LoggerManager.AddLogger("User added");
        return true;
    }

    public bool EditUser(string email, User user)
    {
        var userToEdit = ListOfUsers.FirstOrDefault(x => x.Email == user.Email);
        if (userToEdit == null)
        {
           // LoggerManager.AddLogger("User does not exist");
            return false;
        }
        userToEdit.Name = user.Name;
        userToEdit.Age = user.Age;
        userToEdit.SubscribedCategories = user.SubscribedCategories;
//        LoggerManager.AddLogger("User edited");
        return true;
    }

    public bool DeleteUser(string email)
    {
        var userToDelete = ListOfUsers.FirstOrDefault(x => x.Email == email);
        if (userToDelete == null)
        {
            // LoggerManager.AddLogger("User does not exist");
            return false;
        }
        ListOfUsers.Remove(userToDelete);
      //  LoggerManager.AddLogger("User deleted");
        return true;
    }
    
    
}