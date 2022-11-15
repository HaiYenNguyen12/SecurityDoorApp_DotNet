using Security_Door_App.Logic.DTOs;

namespace Security_Door_App.Logic.Interface
{
    public interface IUser
    {
        Task<int> CreateUser(CreateUserDTO model);
    }
}
