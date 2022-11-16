using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Security_Door_App.Data.Contexts;
using Security_Door_App.Data.Models;
using Security_Door_App.Logic.DTOs;
using Security_Door_App.Logic.Interface;
using Security_Door_App.Logic.ViewModels;

namespace Security_Door_App.Logic.Repository
{
    public class DoorReaderRepository : IDoorReader
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DoorReaderRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateDoorReaderAsync(CreateDoorReaderDTO model)
        {
            model = model ?? throw new ArgumentNullException(nameof(model));
            var reader = _mapper.Map<DoorReader>(model);
            await _context.doorReaders.AddAsync(reader);
            await _context.SaveChangesAsync();
            return 1;
        }
        public async Task<CardReaderVM> GetDoorReaderBySerialNumber(string serial_number)
        {
            var dr = await _context.doorReaders.Include(c => c.Door).FirstOrDefaultAsync(c => c.SerialNumber == serial_number);
            if (dr == null)
            {
                return default;
            }
            return new CardReaderVM
            {
                Id = dr.Id,
                DoorStatus = dr.Door.Status,
                DoorLevel = dr.Door.Level
            };

        }
    }
}
