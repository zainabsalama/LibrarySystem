using LibrarySystem.BL.Dtos;
using LibrarySystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL;

public class RetrievalManager : IRetrievalManager
{
    private readonly IRetrievalRepo _retrievalRepo;

    public RetrievalManager(IRetrievalRepo retrievalRepo)
    {
        _retrievalRepo=retrievalRepo;
    }
    public IEnumerable<RetrievalReadDto> GetAll()
    {
        var retrieve = _retrievalRepo.GetAll();
       return retrieve.Select(x => new RetrievalReadDto
        {
            BookCode=x.BookCode,
            BookTitle=x.BookTitle,
            NumberOfCopies=x.NumberOfCopies,
        });
    }

    public bool Retrieve(RetrievalAddDto dto)
    {
        var book = new Retrieval
        {
            BookCode = dto.BookCode,
            NumberOfCopies = dto.NumberOfCopies,
        };
       

        var numOfCopiesInBorrow = _retrievalRepo.GetNumOfCopies(book.BookCode);
        if(numOfCopiesInBorrow >=book.NumberOfCopies)
        {
            _retrievalRepo.Add(book);
            //_retrievalRepo.DecreaseNumOfCopiesInBorrow();
            _retrievalRepo.SaveChanges();
            _retrievalRepo.IncreaseNumOfCopies(book.BookCode, book.NumberOfCopies);
            return true;
        }
      
     
        return false;
    }
}
