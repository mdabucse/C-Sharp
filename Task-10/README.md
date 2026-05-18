# Mini Microservice with ASP.NET Core

## Project Overview

This project is a Mini Microservice built using ASP.NET Core Web API and Entity Framework Core.

The application provides a RESTful API for managing Books using an In-Memory Database.

This project demonstrates:

- ASP.NET Core Web API
- Controller-Based Architecture
- Dependency Injection
- Entity Framework Core
- Async/Await Operations
- Service Layer Architecture
- Swagger API Documentation
- In-Memory Database Integration

---

# Project Structure

```text
BookService/
│
├── Controllers/
│   └── BooksController.cs
│
├── Models/
│   └── Book.cs
│
├── Interfaces/
│   └── IBookService.cs
│
├── Services/
│   └── BookServiceManager.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Program.cs
├── appsettings.json
└── README.md
```

---

# Technologies Used

| Technology | Purpose |
|---|---|
| C# | Programming Language |
| ASP.NET Core | Web API Framework |
| Entity Framework Core | ORM Framework |
| In-Memory Database | Temporary Data Storage |
| Swagger | API Documentation |
| Dependency Injection | Service Management |

---

# Features Implemented

- RESTful API Architecture
- CRUD Operations
- Controller-Based API
- Dependency Injection
- Service Layer
- Async/Await Database Operations
- Entity Framework Core Integration
- Swagger Documentation
- In-Memory Database Support

---

# Project Setup

## 1. Create Project

```bash
dotnet new webapi -n BookService
```

---

## 2. Navigate to Project

```bash
cd BookService
```

---

## 3. Install Required Packages

### Entity Framework Core

```bash
dotnet add package Microsoft.EntityFrameworkCore
```

### In-Memory Database Provider

```bash
dotnet add package Microsoft.EntityFrameworkCore.InMemory
```

### Swagger Package

```bash
dotnet add package Swashbuckle.AspNetCore
```

---

# Book Model

## Models/Book.cs

```csharp
namespace BookService.Models;

public class Book
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public decimal Price { get; set; }
}
```

---

# DbContext Configuration

## Data/AppDbContext.cs

```csharp
using BookService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
}
```

---

# Service Interface

## Interfaces/IBookService.cs

```csharp
using BookService.Models;

namespace BookService.Interfaces;

public interface IBookService
{
    Task<List<Book>> GetAllBooksAsync();

    Task<Book> AddBookAsync(Book book);
}
```

---

# Service Implementation

## Services/BookServiceManager.cs

```csharp
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
```

---

# Controller Implementation

## Controllers/BooksController.cs

```csharp
using BookService.Interfaces;
using BookService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _bookService.GetAllBooksAsync();

        return Ok(books);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] Book book)
    {
        var createdBook = await _bookService.AddBookAsync(book);

        return Ok(createdBook);
    }
}
```

---

# Program Configuration

## Program.cs

```csharp
using BookService.Data;
using BookService.Interfaces;
using BookService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("BookDb"));

builder.Services.AddScoped<IBookService, BookServiceManager>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
```

---

# API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | /api/books | Get all books |
| POST | /api/books | Add new book |

---

# Sample Request

## POST /api/books

```json
{
  "title": "Clean Code",
  "author": "Robert Martin",
  "price": 499
}
```

---

# Sample Response

```json
{
  "id": 1,
  "title": "Clean Code",
  "author": "Robert Martin",
  "price": 499
}
```

---

# Concepts Learned

- ASP.NET Core Web API
- RESTful API Design
- Controllers and Routing
- Dependency Injection
- Entity Framework Core
- DbContext and DbSet
- In-Memory Database
- Async and Await
- Service Layer Architecture
- Swagger Documentation
- CRUD Operations

---

# Internal Architecture Flow

```text
Client Request
      ↓
Controller
      ↓
Service Layer
      ↓
DbContext
      ↓
In-Memory Database
      ↓
Response Returned
```

---

# Future Improvements

- Add Update and Delete Operations
- Integrate SQLite or PostgreSQL
- Implement Repository Pattern
- Add Global Exception Middleware
- Add Logging
- Add Authentication and Authorization
- Add Unit Testing
- Implement DTOs and AutoMapper

---

# Running the Application

```bash
dotnet run
```

Swagger URL:

```text
https://localhost:xxxx/swagger
```

Replace `xxxx` with your actual port number.