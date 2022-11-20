using Microsoft.AspNetCore.Identity;
using Security_Door_App.Data.Models;

namespace Security_Door_App.API.Services
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<User> _userManager;
        public CurrentUser(IHttpContextAccessor contextAccessor, UserManager<User> userManager)
        {
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        public async Task<User> getCurrentUserAsync()
        {
           var user =  await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
            if (user == null) return default;
            return user;
        }
    }
}
