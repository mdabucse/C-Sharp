using BookService.Data;
using BookService.Interfaces;
using BookService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookService.Services;

public class BookServiceManager : IBookService
{
    private readonly AppDbContext _context;
    public BookServiceManager(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> GetAllBooksAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book> AddBookAsync(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        return book;
    }
}