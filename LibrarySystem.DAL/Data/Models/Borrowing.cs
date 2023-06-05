using LibrarySystem.APIs.DAL;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.DAL;

public class Borrowing
{
    public int BorrowingId { get; set; }

    [Range(1, int.MaxValue)]
    public int NumberOfCopies { get; set; }
    public bool IsRetrieved { get; set; }
    public DateTime BorrowingDate { get; set; } = DateTime.Now;
    public DateTime? RetrievalDate { get; set; }

    public int BookId { get; set; }
    public int MemberId { get; set; }

    public Book? Book { get; set; }
    public Member? Member { get; set; }
}
