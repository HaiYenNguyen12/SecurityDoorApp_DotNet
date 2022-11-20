using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Security_Door_App.Data.Contexts;
using Security_Door_App.Data.Models;
using Security_Door_App.Logic.DTOs;
using Security_Door_App.Logic.Interface;
using Security_Door_App.Logic.ViewModels;

namespace Security_Door_App.Logic.Repository
{
    public class CardRepository : ICard
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        public CardRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
          
        }

        public async Task<int> CreateCardAsync(CreateCardDTO model)
        {
            model = model ?? throw new ArgumentNullException(nameof(model));
            var exist_card =await  _context.Cards.Where(c => c.IdUser == model.IdUser).FirstOrDefaultAsync();
            if (exist_card != null) return -1;
            var card = _mapper.Map<Card>(model);
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleCardAsync(int id)
        {
           var card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);
           if (card == null) return -1;
           _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
            return card.Id;

        }

        public async Task<IEnumerable<CardVM>> GetAllCardsAsync()
        {
            var list = await _context.Cards.ToListAsync();
            if (list == null)
                return new List<CardVM>();
            return _mapper.Map<IEnumerable<CardVM>>(list);
        }

        public async Task<CardVM> GetCardByIdAsync(int id)
        {
            var card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);
            if (card == null) return default; 
            var cardVM = _mapper.Map<CardVM>(card);
            return cardVM;
        }

        public async Task<CardVM> GetCardByIdUser(string userId)
        {
            var card = await _context.Cards.FirstOrDefaultAsync(c => c.IdUser == userId);
            if (card == null) return default;
            var cardVM = _mapper.Map<CardVM>(card);
            return cardVM;
        }

        public async Task<CardVM> GetCardByUniqueNumber(string unique_number)
        {
          var card =   await _context.Cards.FirstOrDefaultAsync(c => c.UniqueNumber == unique_number);
            if (card == null)
            {
                return default;
            }
            return new CardVM
            {
                Id = card.Id,
                CardStatus = card.Status,
                CardLevel = card.Level,
            };
        }

        public async Task<int> UpdateCardAsync(CardVM model)
        {
            var card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == model.Id);
            if (card == null)
            {
                return default;
            }
            card.Level = model.CardLevel;
            card.Status = model.CardStatus;
            await _context.SaveChangesAsync();
            return card.Id;

        }
    }
}
