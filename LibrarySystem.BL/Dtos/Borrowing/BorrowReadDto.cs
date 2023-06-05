namespace LibrarySystem.BL.Dtos;

public class BorrowReadDto
{
    public int Id { get; set; }
    public int BookCode { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public int NumberOfCopies { get; set; }
}
