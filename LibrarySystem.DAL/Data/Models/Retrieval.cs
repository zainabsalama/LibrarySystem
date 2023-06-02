using LibrarySystem.APIs.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DAL;

public class Retrieval
{
    public int RetrievalId { get; set; }

    public int BookCode{ get; set; }

    public int MemberCode { get; set; }

    public string BookTitle { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "Number of copies must be at least 1.")]
    public int NumberOfCopies { get; set; }

    public Book? Book { get; set; }

    public Member? Member { get; set; }
}
