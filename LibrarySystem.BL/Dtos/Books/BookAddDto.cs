using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.Dtos.Books
{
    public class BookAddDto
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Title { get; set; } = string.Empty;

        public int NumOfCopies { get; set; }
    }
}
