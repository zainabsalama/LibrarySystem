using LibrarySystem.BL.Dtos;

namespace LibrarySystem.BL;

public interface IBorrowingManager
{
    IEnumerable<BorrowReadDto> Get();

    bool Borrow(BorrowAddDto borrowAddDto);

    void CloseBorrwoing(int id);
}
