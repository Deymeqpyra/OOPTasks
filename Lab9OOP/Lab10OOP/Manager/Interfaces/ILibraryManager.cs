using Lab10OOP.Entity;

namespace Lab10OOP.Manager.Interfaces;

public interface ILibraryManager
{
    bool RegisterUser(string email, int age, string name, List<Category>? categories);
    bool UpdateUser(string email, int age, string name, List<Category> categories);
    bool DeleteUser(string email);
    bool RegisterBook(string title, string author, Category category);
    bool UpdateBook(string title, string bookName);
    bool DeleteBook(Book book);
    bool SubscribeBookCategory(Category category, string email);
    bool NotifyAllUsers(Category category, string message);
    void GetLog();
}