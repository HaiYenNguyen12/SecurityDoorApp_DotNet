using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Security_Door_App.Data.Contexts;
using Security_Door_App.Data.Models;
using Security_Door_App.Logic.DTOs;
using Security_Door_App.Logic.Interface;

namespace Security_Door_App.Logic.Repository
{
    public class DoorRepository : IDoor
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DoorRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateDoorAsync(CreateDoorDTO model)
        {
            model = model ?? throw new ArgumentNullException(nameof(model));
            var door = _mapper.Map<Door>(model);
            await _context.Doors.AddAsync(door);
            await _context.SaveChangesAsync();
            return 1;
        }

       
    }
}
