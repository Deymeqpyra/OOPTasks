using Lab10OOP.Entity;

namespace Lab10OOP.Manager.Interfaces;

public interface IBookManager
{
    List<Book> GetAllBooks();
    bool DeleteBook(string name, string author);
    bool EditBook(Book bookToUpdate, Book updatedBook);
    bool AddBook(Book book);
}