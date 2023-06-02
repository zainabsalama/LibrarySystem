using LibrarySystem.APIs.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.Dtos;

public class RetrievalAddDto
{
    public int BookCode { get; set; }

  
    public int NumberOfCopies { get; set; }

}
