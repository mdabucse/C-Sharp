using BookService.Data;
using BookService.Interfaces;
using BookService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add Controllers
builder.Services.AddControllers();

// Swagger Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register In-Memory Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("BookDb"));

// Register Service Layer
builder.Services.AddScoped<IBookService, BookServiceManager>();

var app = builder.Build();

// Swagger Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS Middleware
app.UseHttpsRedirection();

// Map Controllers
app.MapControllers();

// Run Application
app.Run();