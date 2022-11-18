using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Security_Door_App.API.Account;
using Security_Door_App.Data.Models;
using Security_Door_App.Logic.DTOs;


namespace Security_Door_App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _repo;
     
   
        public UserController(IUser repo)
        {
            _repo = repo;
        }
        [HttpPost("register")]
        public async Task<IActionResult> AddUserAsync(CreateUserDTO model)
        {
            var result = await _repo.CreateAsync(model);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginDTO model)
        {
            var result = await _repo.LoginAsync(model);
            return Ok(result);
        }


        [Authorize]
        //[ValidateAntiForgeryToken]
        [HttpPost("logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            var result = await _repo.LogOutAsync();
            return Ok(result);
        }
        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var result = await _repo.ConfirmEmail(userId,token);
            return Ok(result);
        }


    }
}
