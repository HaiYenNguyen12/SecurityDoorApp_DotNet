using Security_Door_App.Logic.DTOs;

namespace Security_Door_App.Logic.Interface
{
    public interface IDoorReader
    {

        Task<int> CreateDoorReaderAsync(CreateDoorReaderDTO model);
        Task<int> GetDoorReaderBySerialNumber(string serial_number);
    }
}
