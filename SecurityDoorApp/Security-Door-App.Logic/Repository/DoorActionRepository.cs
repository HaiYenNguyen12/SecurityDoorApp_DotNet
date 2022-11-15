using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Security_Door_App.Data.Contexts;
using Security_Door_App.Data.Models;
using Security_Door_App.Logic.DTOs;
using Security_Door_App.Logic.Interface;

namespace Security_Door_App.Logic.Repository
{
    public class DoorActionRepository : IDoorAction
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DoorActionRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateDoorActionAsync(CreateDoorActionDTO model)
        {
            model = model ?? throw new ArgumentNullException(nameof(model));
            var action = _mapper.Map<DoorAction>(model);
            await _context.DoorActions.AddAsync(action);
            await _context.SaveChangesAsync();
            return 1;
        }
    }
}
