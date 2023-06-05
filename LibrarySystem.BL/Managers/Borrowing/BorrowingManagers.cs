using LibrarySystem.BL.Dtos;
using LibrarySystem.DAL;

namespace LibrarySystem.BL;

public class BorrowingManagers : IBorrowingManager
{
    private readonly IBorrowingRepo _borrowingRepo;
    private readonly IBooksRepo _booksRepo;

    public BorrowingManagers(IBorrowingRepo borrowingRepo,
        IBooksRepo booksRepo)
    {
        _borrowingRepo = borrowingRepo;
        _booksRepo = booksRepo;
    }
    public bool Borrow(BorrowAddDto borrowAddDto)
    {
        var borrowBook = new Borrowing
        {
            MemberId= borrowAddDto.MemberId,
            BookId = borrowAddDto.BookId,
            NumberOfCopies = borrowAddDto.NumberOfCopies,
        };

        var book = _booksRepo.GetById(borrowAddDto.BookId);
        if (book == null)
        {
            return false;
        }

        if (book.NumOfCopies < borrowBook.NumberOfCopies)
        {
            return false;
        }

        book.NumOfCopies -= borrowBook.NumberOfCopies;

        _borrowingRepo.Add(borrowBook);
        _borrowingRepo.SaveChanges();

        return true;
    }

    public void CloseBorrwoing(int id)
    {
        var borrowing = _borrowingRepo.GetWithBookById(id);
        if (borrowing is null)
            return;
        borrowing.IsRetrieved = true;
        borrowing.RetrievalDate = DateTime.Now;
        borrowing.Book!.NumOfCopies += borrowing.NumberOfCopies;

        _borrowingRepo.Update();
        _borrowingRepo.SaveChanges();
    }

    public IEnumerable<BorrowReadDto> Get()
    {
        var BorrowBooks = _borrowingRepo.GetPendingWithBooks();
        return BorrowBooks.Select(d => new BorrowReadDto
        {
            Id = d.BookId,
            BookCode = d.Book!.Code,
            NumberOfCopies = d.NumberOfCopies,
            BookTitle = d.Book!.Title,
        });
    }
}
