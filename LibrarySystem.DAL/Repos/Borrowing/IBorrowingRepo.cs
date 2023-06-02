using LibrarySystem.APIs.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DAL;

public interface IBorrowingRepo
{
    IEnumerable<Borrowing> GetAll();
    void Add(Borrowing borrowing);
    void Delete(Borrowing borrowing);
    void DecreaseBookCopies(int bookCode, int numOfCopies);
    int GetNumberOfCopies(int bookCode);
    int SaveChanges();

}
