using BookService.Models;

namespace BookService.Interfaces;

public interface IBookService
{
    Task<List<Book>> GetAllBooksAsync();

    Task<Book> AddBookAsync(Book book);
}