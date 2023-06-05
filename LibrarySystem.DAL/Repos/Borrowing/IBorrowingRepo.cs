namespace LibrarySystem.DAL;

public interface IBorrowingRepo
{
    IEnumerable<Borrowing> GetPendingWithBooks();
    Borrowing? GetWithBookById(int id);
    void Add(Borrowing borrowing);
    void Delete(Borrowing borrowing);
    void Update();
    int SaveChanges();
}
