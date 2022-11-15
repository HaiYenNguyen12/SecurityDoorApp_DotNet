using Security_Door_App.Logic.DTOs;

namespace Security_Door_App.Logic.Interface
{
    public interface IDoor
    {
        Task<int> CreateDoorAsync(CreateDoorDTO model);
    }
}
