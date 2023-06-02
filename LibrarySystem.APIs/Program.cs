using LibrarySystem.APIs;
using LibrarySystem.APIs.DAL;
using LibrarySystem.BL;
using LibrarySystem.BL.Managers.Books;
using LibrarySystem.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("LibrarySystem");
builder.Services.AddDbContext<SystemContext>(options=>options.UseSqlServer(connectionString));
builder.Services.AddScoped<IBooksRepo,BooksRepo>();
builder.Services.AddScoped<IBookManagers, BookManagers>();
builder.Services.AddScoped<IBorrowingRepo, BorrowingRepo>();
builder.Services.AddScoped<IBorrowingManager, BorrowingManagers>();
builder.Services.AddScoped<IRetrievalRepo, RetrievalRepo>();
builder.Services.AddScoped<IRetrievalManager, RetrievalManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
