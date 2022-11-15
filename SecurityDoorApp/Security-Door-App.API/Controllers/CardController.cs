using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security_Door_App.Logic.DTOs;
using Security_Door_App.Logic.Interface;

namespace Security_Door_App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICard _repo;
        public CardController(ICard repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync(CreateCardDTO model)
        {
            var result = await _repo.CreateCardAsync(model);
            return Ok(result);
        }
    }
}
