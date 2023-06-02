using LibrarySystem.APIs.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DAL;

public class BorrowingRepo:IBorrowingRepo
{
    private readonly SystemContext _context;

    public BorrowingRepo(SystemContext context )
    {
        _context = context;
    }

    public void Add(Borrowing borrowing)
    {
        _context.Borrow.Add(borrowing);
    }

    public void Delete(Borrowing borrowing)
    {
        _context.Borrow.Remove(borrowing);
    }

    public IEnumerable<Borrowing> GetAll()
    {
        return _context.Borrow;
    }

    public int GetNumberOfCopies(int bookCode)
    {
        int numberOfCopies = _context.Books
            .Where(b => b.Code == bookCode)
            .Select(b => b.NumOfCopies)
            .SingleOrDefault();

        return numberOfCopies;
    }

    public void DecreaseBookCopies(int bookCode, int numOfCopies)
    {
        var book = _context.Books.FirstOrDefault(b => b.Code == bookCode);
        if (book != null)
        {
            book.NumOfCopies -= numOfCopies;
            _context.SaveChanges();
        }
    }


    public int SaveChanges()
    {
       return _context.SaveChanges();

    }

    public int GetNumberOfCopies(Borrowing borrowing)
    {
        throw new NotImplementedException();
    }
}
