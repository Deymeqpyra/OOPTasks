using Lab10OOP.Entity;
using Lab10OOP.Manager.Interfaces;

namespace Lab10OOP.Manager;

public class BookManager : IBookManager
{
    private List<Book> _books = new List<Book>();
    private ILoggerManager loggerManager;

    public BookManager(ILoggerManager loggerManager)
    {
        this.loggerManager = loggerManager;
    }
    public bool AddBook(Book book)
    {
        if (book == null)
        {
            loggerManager.ErrorLogger($"Book parameter cannot be null");
            return false;
        }
        _books.Add(book);
        return true;
    }

    public bool EditBook(Book bookToUpdate, Book updatedBook)
    {
        var bookToEdit = _books.FirstOrDefault(x=>x.Title == bookToUpdate.Title);
        if (bookToEdit == null)
        {
            // LoggerManager.AddLogger("Book is not exist");
            return false;
        }
        bookToEdit.Title = updatedBook.Title;
        bookToEdit.Author = updatedBook.Author;
        bookToEdit.Category = updatedBook.Category;
        // LoggerManager.AddLogger("Book updated");
        return true;
    }

    public bool DeleteBook(string title, string author)
    {
        var bookToDelete = _books.FirstOrDefault(x => x.Title == title && x.Author == author);
        if (bookToDelete == null)
        {
            // LoggerManager.AddLogger("Book is not exist");
            return false;
        }
        _books.Remove(bookToDelete);
        // LoggerManager.AddLogger("Book deleted");
        return true;
    }
}