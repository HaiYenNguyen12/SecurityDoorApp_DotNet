using Security_Door_App.Logic.DTOs;
using Security_Door_App.Logic.ViewModels;

namespace Security_Door_App.Logic.Interface
{
    public interface ICard
    {
        Task<int> CreateCardAsync(CreateCardDTO model);
        Task<IEnumerable<CardVM>> GetAllCardsAsync();
        Task<CardVM> GetCardByUniqueNumber(string unique_number);

        Task<CardVM> GetCardByIdAsync(int id);
        Task<int> UpdateCardAsync(CardVM model);
        Task<int> DeleCardAsync(int id);
        Task<CardVM> GetCardByIdUser(string user);
    }
}
