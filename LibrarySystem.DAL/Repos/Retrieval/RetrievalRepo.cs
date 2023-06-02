using LibrarySystem.APIs.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DAL;

public class RetrievalRepo : IRetrievalRepo
{
    private readonly SystemContext _context;

    public RetrievalRepo(SystemContext context)
    {
        _context = context;
    }
    public void Add(Retrieval retrieval)
    {
        _context.Retrieval.Add(retrieval);
    }

    public void Delete(Retrieval retrieval)
    {
        _context.Retrieval.Remove(retrieval);
    }

    public IEnumerable<Retrieval> GetAll()
    {
        return _context.Retrieval;
    }

    public void IncreaseNumOfCopies(int bookCode, int numOfCopies)
    {
        var book = _context.Books.FirstOrDefault(d => d.Code == bookCode);
        if (book != null)
        {
            book.NumOfCopies += numOfCopies;
            _context.SaveChanges();
        }
    }
    public void DecreaseNumOfCopiesInBorrow(int borrowId)
    {
        var borrowBook = _context.Borrow.FirstOrDefault(d => d.BorrowingId == borrowId);
        if(borrowBook != null)
        {
            _context.Borrow.Remove(borrowBook);
            _context.SaveChanges();
        }
    }
    public int GetNumOfCopies(int bookCode)
    {
        var bookCopies = _context.Borrow
       .Where(d => d.BookCode == bookCode)
       .Sum(d => d.NumberOfCopies); // Use Sum to get the total number of copies in borrow

        return bookCopies;
    }

    public int SaveChanges()
    {
       return _context.SaveChanges();
    }
}
