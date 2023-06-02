using LibrarySystem.BL.Dtos;
using LibrarySystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL;

public class BorrowingManagers : IBorrowingManager
{
    private readonly IBorrowingRepo _borrowingRepo;

    public BorrowingManagers(IBorrowingRepo borrowingRepo)
    {
        _borrowingRepo = borrowingRepo;
    }
    public bool Borrow(BorrowAddDto borrowAddDto)
    {

        var borrowBook = new Borrowing
        {
            BookCode = borrowAddDto.BookCode,
            NumberOfCopies = borrowAddDto.NumberOfCopies,
        };

        var numOfCopiesInDb = _borrowingRepo.GetNumberOfCopies(borrowBook.BookCode);
        if (numOfCopiesInDb < borrowBook.NumberOfCopies)
        {
            return false;
        }

        _borrowingRepo.Add(borrowBook);
        _borrowingRepo.SaveChanges();

        _borrowingRepo.DecreaseBookCopies(borrowBook.BookCode, borrowBook.NumberOfCopies);

        return true;

    }

    public IEnumerable<BorrowReadDto> Get()
    {
        var BorrowBooks=_borrowingRepo.GetAll();
        return BorrowBooks.Select(d => new BorrowReadDto
        {
            BookCode = d.BookCode,
            NumberOfCopies = d.NumberOfCopies,
            BookTitle= d.BookTitle,
        });
    }
}
