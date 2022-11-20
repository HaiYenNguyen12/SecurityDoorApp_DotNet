using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security_Door_App.Data.Attributes;
using Security_Door_App.Data.Constants;
using Security_Door_App.Logic.DTOs;
using Security_Door_App.Logic.Interface;
using Security_Door_App.Logic.ViewModels;

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
        public async Task<IActionResult> AddCardAsync(CreateCardDTO model)
        {
            var result = await _repo.CreateCardAsync(model);
            return Ok(result);
        }
        [AuthorizeRoles(RoleConstant.Admin)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DelCardAsync(int id)
        {
            var res = await _repo.DeleCardAsync(id);
            if (res == -1) return BadRequest("Not found item to delete");
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCardByIdAsync(int id)
        {
            var res = await _repo.GetCardByIdAsync(id);
            if (res == null) return NotFound();
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCardAsync()
        {
            var res = await _repo.GetAllCardsAsync();
            return Ok(res);
        }

        [HttpGet("User/{IdUser}")]
        public async Task<IActionResult> GetCardByIdAUserAsync(string IdUser)
        {
            var res = await _repo.GetCardByIdUser(IdUser);
            if (res == null) return NotFound();
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCard(CardVM model)
        {
            var res = await _repo.UpdateCardAsync(model);
            if (res == -1) return NotFound();
            return Ok(res);
        }





    }
}
