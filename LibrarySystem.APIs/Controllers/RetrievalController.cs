using LibrarySystem.BL;
using LibrarySystem.BL.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetrievalController : ControllerBase
    {
        private readonly IRetrievalManager _retrievalManager;

        public RetrievalController(IRetrievalManager retrievalManager) 
        { 
            _retrievalManager=retrievalManager;
        }
        [HttpGet]
        public ActionResult<List<RetrievalReadDto>> GetAll()
        {
            return _retrievalManager.GetAll().ToList();
        }

        [HttpPost]
        public ActionResult Retrieve(RetrievalAddDto retrievalAddDto)
        {
            var isFound= _retrievalManager.Retrieve(retrievalAddDto);
            if(!isFound)
            {
                return NotFound();
            }
            return Ok("Book was Retrieved");

        }
    }
}
