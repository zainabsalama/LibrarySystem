using LibrarySystem.APIs.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DAL;

public interface IBooksRepo
{
    IEnumerable<Book> GetAll();

    void Add(Book book);

    Book? GetById(int id);

    void Update(Book book);

    void Delete(Book book);

    int saveChanges();
}
