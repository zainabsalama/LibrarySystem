using LibrarySystem.BL;
using LibrarySystem.BL.Dtos.Books;
using LibrarySystem.BL.Dtos.General;
using LibrarySystem.BL.Managers.Books;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.APIs.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookManagers _bookManagers;

    public BookController(IBookManagers bookManagers)
    {
        _bookManagers = bookManagers;
    }

    [HttpGet]
    public ActionResult<List<BookReadDto>> GetAll()
    {
        return _bookManagers.GetAll().ToList();
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<BookReadDto> GetById(int id)
    {
        var book=_bookManagers.GetById(id);
        if(book == null)
        {
            return NotFound();
        }
        return book;
    }

    [HttpPost]
    public ActionResult Add(BookAddDto bookDto)
    {
        var newId = _bookManagers.Add(bookDto);
        return CreatedAtAction(nameof(GetById),
            new {id=newId},
            new GeneralResponse("Book was Added"));
    }
    [HttpPut]
    public ActionResult Update(BookUpdateDto bookDto)
    {
        var updatedBook=_bookManagers.Update(bookDto);
        if(!updatedBook)
        {
            return NotFound();
        }
        return NoContent();
    }
    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete(int id)
    {
       var deletedBook= _bookManagers.Delete(id);
        if(!deletedBook)
        {
            return NotFound();
        }
        return NoContent();
    }
}
