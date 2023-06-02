using LibrarySystem.APIs.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DAL;

public class BooksRepo : IBooksRepo
{
    private readonly SystemContext _context;

    public BooksRepo(SystemContext context)
    {
        _context = context;
    }
    public void Add(Book book)
    {
        _context.Books.Add(book);
    }

    public void Delete(Book book)
    {
        _context.Books.Remove(book);
    }

    public IEnumerable<Book> GetAll()
    {
       return _context.Books;
    }

    public Book? GetById(int id)
    {
        return _context.Books.Find(id);
    }

    public int saveChanges()
    {
        return _context.SaveChanges();
    }

    public void Update(Book book)
    {
        //Default Tracking
    }
}
