using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Security_Door_App.Logic.DTOs;
using Security_Door_App.Logic.Interface;

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
            var result = await _repo.CreateUser(model);
            return Ok(result);
        }
        
    

    }
}
