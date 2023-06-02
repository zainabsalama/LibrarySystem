using LibrarySystem.BL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL;

public interface IBorrowingManager
{
    IEnumerable<BorrowReadDto> Get();

    bool Borrow(BorrowAddDto borrowAddDto);
}
