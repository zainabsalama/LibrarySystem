using LibrarySystem.APIs.DAL;
using LibrarySystem.BL.Dtos.Books;
using LibrarySystem.BL.Managers.Books;
using LibrarySystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL;

public class BookManagers : IBookManagers
{
    private readonly IBooksRepo _bookRepo;

    public BookManagers(IBooksRepo booksRepo)
    {
        _bookRepo = booksRepo;
    }
    public int Add(BookAddDto bookAddDto)
    {
        var book = new Book
        {
            Title = bookAddDto.Title,
            NumOfCopies = bookAddDto.NumOfCopies,
        };
        _bookRepo.Add(book);
        _bookRepo.saveChanges();
        return book.Id;
    }

    public bool Delete(int id)
    {
        var book= _bookRepo.GetById(id);
        if(book==null)
            return false;
        _bookRepo.Delete(book);
        _bookRepo.saveChanges();
        return true;

    }

    public IEnumerable<BookReadDto> GetAll()
    {
        var BooksFromDb = _bookRepo.GetAll();
        return BooksFromDb.Select(d => new BookReadDto
        {
            Id = d.Id,
            Title = d.Title,
            NumOfCopies = d.NumOfCopies,
        }) ;
    }

    public BookReadDto? GetById(int id)
    {
        var GetBookFromDb = _bookRepo.GetById(id);
        if(GetBookFromDb == null)
        {
            return null;
        }
        return new BookReadDto
        { 
            Id = GetBookFromDb.Id,
            Title = GetBookFromDb.Title,
            NumOfCopies= GetBookFromDb.NumOfCopies
        };
    }

    public bool Update(BookUpdateDto bookUpdateDto)
    {
        var book = _bookRepo.GetById(bookUpdateDto.Id);
        if(book==null) return false;
        book.Title = bookUpdateDto.Title;
        book.NumOfCopies= bookUpdateDto.NumOfCopies;
        _bookRepo.Update(book);
        _bookRepo.saveChanges();
        return true;
    }
}
