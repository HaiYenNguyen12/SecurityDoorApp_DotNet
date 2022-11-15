using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Security_Door_App.Data.Contexts;
using Security_Door_App.Data.Models;
using Security_Door_App.Logic.DTOs;
using Security_Door_App.Logic.Interface;

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
        public async Task<int> GetDoorReaderBySerialNumber(string serial_number)
        {
            var dr = await _context.doorReaders.FirstOrDefaultAsync(c => c.SerialNumber == serial_number);
            if (dr == null)
            {
                return -1;
            }
            return dr.Id;

        }
    }
}
