using Lab10OOP.Entity;
using Lab10OOP.Manager.Interfaces;

namespace Lab10OOP.Manager;

public class LibraryApp : 
{
    private IUserManager _userManager;
    private IBookManager _bookManager;
    private ILoggerManager _loggerManager;

    public LibraryApp(IUserManager userManager, IBookManager bookManager, ILoggerManager loggerManager)
    {
        _userManager = userManager;
        _bookManager = bookManager;
        _loggerManager = loggerManager;
    }

    public bool RegisterUser(string email, int age,  string name)
    {
        
        User newUser = new User()
        {
            Email = email,
            Age = age,
            Name = name
        };
        _userManager.RegisterUser(newUser);
        return true;
    }

    public bool RegisterBook(string title, string author, Category category)
    {
        Book newBook = new Book()
        {
            Title = title,
            Author = author,
            Category = category
        };
        _bookManager.AddBook(newBook);
        return true;
    }

    public List<String> GelLog()
    {
       return _loggerManager.GetLoggerList();
    }
}