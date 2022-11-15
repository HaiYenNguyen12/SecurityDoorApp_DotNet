using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security_Door_App.Logic.DTOs;
using Security_Door_App.Logic.Interface;

namespace Security_Door_App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorReaderController : ControllerBase
    {
        private readonly IDoorReader _repo;
        public DoorReaderController(IDoorReader repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync(CreateDoorReaderDTO model)
        {
            var result = await _repo.CreateDoorReaderAsync(model);
            return Ok(result);
        }
    }
}
