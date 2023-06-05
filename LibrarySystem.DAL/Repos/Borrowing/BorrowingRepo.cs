using LibrarySystem.APIs.DAL;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.DAL;

public class BorrowingRepo : IBorrowingRepo
{
    private readonly SystemContext _context;

    public BorrowingRepo(SystemContext context)
    {
        _context = context;
    }

    public void Add(Borrowing borrowing)
    {
        _context.Borrows.Add(borrowing);
    }

    public void Delete(Borrowing borrowing)
    {
        _context.Borrows.Remove(borrowing);
    }

    public IEnumerable<Borrowing> GetPendingWithBooks()
    {
        return _context.Borrows
            .Include(b => b.Book)
            .Where(b => !b.IsRetrieved)
            .AsNoTracking();
    }

    public Borrowing? GetWithBookById(int id)
    {
        return _context.Set<Borrowing>()
            .Include(b => b.Book)
            .FirstOrDefault(b => b.BorrowingId == id);
    }

    public void Update()
    {
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();

    }
}
