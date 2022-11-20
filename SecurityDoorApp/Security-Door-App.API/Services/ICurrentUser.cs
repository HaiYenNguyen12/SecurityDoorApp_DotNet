using Security_Door_App.Data.Models;

namespace Security_Door_App.API.Services
{
    public interface ICurrentUser
    {
        Task<User> getCurrentUserAsync();
    }
}
