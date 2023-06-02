using LibrarySystem.BL;
using LibrarySystem.BL.Dtos;
using LibrarySystem.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowController : ControllerBase
    {
        private readonly IBorrowingManager _borrowingManager;

        public BorrowController(IBorrowingManager borrowingManager)
        { 
            _borrowingManager= borrowingManager;
        }

        [HttpGet]
        public ActionResult<List<BorrowReadDto>> GetAll()
        {
            return _borrowingManager.Get().ToList();
        }

        [HttpPost]

        public ActionResult Add(BorrowAddDto borrowAddDto)
        {
           var isAdded= _borrowingManager.Borrow(borrowAddDto);
            if (!isAdded)
            {
                return NotFound();
            }
            return Ok("Was Added Successfully");
        }
    }
}
