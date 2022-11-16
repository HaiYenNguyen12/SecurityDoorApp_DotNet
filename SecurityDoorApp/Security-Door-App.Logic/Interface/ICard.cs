using Security_Door_App.Logic.DTOs;
using Security_Door_App.Logic.ViewModels;

namespace Security_Door_App.Logic.Interface
{
    public interface ICard
    {
        Task<int> CreateCardAsync(CreateCardDTO model);
        Task<CardVM> GetCardByUniqueNumber(string unique_number);
    }
}
