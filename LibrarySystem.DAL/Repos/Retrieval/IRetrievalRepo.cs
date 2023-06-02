using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DAL;

public interface IRetrievalRepo
{
    IEnumerable<Retrieval> GetAll();

    void Add(Retrieval retrieval);

    void Delete(Retrieval retrieval);

    int GetNumOfCopies(int bookCode);

    void DecreaseNumOfCopiesInBorrow(int borrowId);

    void IncreaseNumOfCopies(int bookCode, int numOfCopies);
    int SaveChanges();
}
