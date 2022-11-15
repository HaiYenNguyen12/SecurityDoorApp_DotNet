using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security_Door_App.Logic.DTOs;
using Security_Door_App.Logic.Interface;

namespace Security_Door_App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorController : ControllerBase
    {
        private readonly IDoor _repo;
        public DoorController(IDoor repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public async Task<IActionResult> AddUserAsync(CreateDoorDTO model)
        {
            var result = await _repo.CreateDoorAsync(model);
            return Ok(result);
        }
    }
}
