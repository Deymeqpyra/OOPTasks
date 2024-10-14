using Lab10OOP.Entity;
using Lab10OOP.Manager.Interfaces;

namespace Lab10OOP.Manager;

public class LibraryManager : ILibraryManager
{
    private IUserManager _userManager;
    private IBookManager _bookManager;
    private ILoggerManager _loggerManager;
    private INotificationService _notificationService;

    public LibraryManager(IUserManager userManager, IBookManager bookManager, ILoggerManager loggerManager, INotificationService notificationService)
    {
        _userManager = userManager;
        _bookManager = bookManager;
        _loggerManager = loggerManager;
        _notificationService = notificationService;
    }

    public bool SubscribeBookCategory(Category category, string email)
    {
        var userToFind = _userManager.GetAllUsers().FirstOrDefault(u => u.Email == email);
        if (userToFind == null || category == null) 
        {
            _loggerManager.ErrorLogger("User not found");
            return false;
        }
        _loggerManager.InfoLogger($"User {userToFind.Email} was subscribed for {category.Name}");
        userToFind.SubscribedCategories.Add(category);
        _userManager.EditUser(email, userToFind);
        return true;
    }
    
    public bool RegisterUser(string email, int age,  string name, List<Category>? categories)
    {
        if(string.IsNullOrEmpty(email) 
            || age < 1 
            || age > 100 
            || string.IsNullOrEmpty(name) 
            || (!email.Contains('@') && !email.Contains('.')))
            {
                _loggerManager.ErrorLogger("Input was incorrect when trying to register user");
                return false;
            }
        User newUser = new User()
        {
            Email = email,
            Age = age,
            Name = name,
            SubscribedCategories = categories
        };
        if (!_userManager.AddUser(newUser))
        {
            _loggerManager.ErrorLogger("Unknown error was invoked");
            return false;
        }
        return true;
    }

    public bool UpdateUser(string email, int age, string name, List<Category> categories)
    {
        User updateUser = new User()
        {
            Email = email,
            Age = age,
            Name = name,
            SubscribedCategories = categories
        };
        if (!_userManager.EditUser(email, updateUser))
        {
            return false;
        }
        _loggerManager.InfoLogger($"User was edited Age: {updateUser.Age} and Name: {updateUser.Name}");
        return true;
    }

    public bool DeleteUser(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return false;
        }

        if (!_userManager.DeleteUser(email))
        {
            return false;
        }
        _loggerManager.InfoLogger($"User was deleted {email}");
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
        if (!_bookManager.AddBook(newBook))
        {
            return false;
        }
        NotifyAllUsers(category, $"Book {newBook.Title} from {newBook.Author} was added to library.");
        return true;
    }

    public bool UpdateBook(string titleUpdate, string bookName)
    {
        var bookToFind = _bookManager.GetAllBooks().FirstOrDefault(x=>x.Title == bookName);
        Book updateBook = new Book()
        {
            Title = titleUpdate,
            Author = bookToFind.Author,
            Category = bookToFind.Category
        };
        if (!_bookManager.EditBook(bookToFind, updateBook))
        {
            return false;
        }
        NotifyAllUsers(bookToFind.Category, $"Book {bookToFind.Title} updated to {titleUpdate}");
        return true;
    }
    public bool DeleteBook(Book bookToDelete)
    {
        if (bookToDelete == null)
        {
            _loggerManager.ErrorLogger("Book not found");
            return false;
        }
        if (!_bookManager.DeleteBook(bookToDelete.Title, bookToDelete.Author))
        {
            _loggerManager.ErrorLogger("Unknown error");
            return false;
        }
        _loggerManager.InfoLogger("Book deleted");
        NotifyAllUsers(bookToDelete.Category, $"Book {bookToDelete.Title} was deleted");
        return true;
    }

    public bool NotifyAllUsers(Category category, string message)
    {
        var usersWithCategory = _userManager
            .GetAllUsers()
            .Where(x=>x.SubscribedCategories.Contains(category) && x.SubscribedCategories != null )
            .ToList();
        
        if (!usersWithCategory.Any())
        {
            _loggerManager.ErrorLogger("List is empty");
            return false;
        }
        foreach (var user in usersWithCategory)
        {
            _notificationService.NotifyUser(user, message);
            _loggerManager.InfoLogger($"User {user.Email} was notified with {message}");
        }
        return true;
    }
    
    
    public void GetLog()
    {
        _loggerManager.ShowLog();
    }
}