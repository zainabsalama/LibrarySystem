using LibrarySystem.BL.Dtos.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.Managers.Books
{
    public interface IBookManagers
    {
        IEnumerable<BookReadDto> GetAll();

        BookReadDto? GetById(int id);

        int Add(BookAddDto bookAddDto);

        bool Update(BookUpdateDto bookUpdateDto);

        bool Delete(int id);

    }
}
