using Security_Door_App.Logic.DTOs;
using Security_Door_App.Logic.ViewModels;

namespace Security_Door_App.Logic.Interface
{
    public interface IDoorReader
    {

        Task<int> CreateDoorReaderAsync(CreateDoorReaderDTO model);
        Task<CardReaderVM> GetDoorReaderBySerialNumber(string serial_number);
    }
}
