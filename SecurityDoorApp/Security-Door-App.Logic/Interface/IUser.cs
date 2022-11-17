using Security_Door_App.Logic.DTOs;

namespace Security_Door_App.Logic.Interface
{
    public interface IUser
    {
        Task<int> CreateAsync(CreateUserDTO model);
        Task<string> LoginAsync(LoginDTO model);
    }
}
