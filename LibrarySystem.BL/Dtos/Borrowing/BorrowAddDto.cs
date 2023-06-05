namespace LibrarySystem.BL.Dtos;

public class BorrowAddDto
{
    public int BookId { get; set; }
    public int MemberId { get; set; }
    public int NumberOfCopies { get; set; }
}
