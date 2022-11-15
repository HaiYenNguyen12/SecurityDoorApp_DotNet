using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security_Door_App.Logic.DTOs;
using Security_Door_App.Logic.Interface;

namespace Security_Door_App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorActionController : ControllerBase
    {
        private readonly IDoorAction _repo;
        public DoorActionController(IDoorAction repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateDoorActionDTO model)
        {
            var result = await _repo.CreateDoorActionAsync(model);
            return Ok(result);
        }
    }
}
