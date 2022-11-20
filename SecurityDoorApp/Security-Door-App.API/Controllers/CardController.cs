using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security_Door_App.API.Account;
using Security_Door_App.API.Services;
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
        private readonly ICurrentUser _currentUser;
        private readonly IUser _userSerivce;
        
        public CardController(ICard repo, ICurrentUser userService,IUser user)
        {
            _repo = repo;
            _currentUser = userService;
            _userSerivce = user;
            
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddCardAsync(CreateCardDTO model)
        {
            var user = await _currentUser.getCurrentUserAsync();
            model.IdUser = user.Id;
            model.Level =await _userSerivce.GetRolesByUser(user);

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
        [Authorize]
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
