using Security_Door_App.Logic.DTOs;

namespace Security_Door_App.Logic.Interface
{
    public interface IDoorAction
    {
        Task<int> CreateDoorActionAsync(CreateDoorActionDTO model);
    }
}
