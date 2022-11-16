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
            var card = _mapper.Map<Card>(model);
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();
            return 1;
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
    }
}
