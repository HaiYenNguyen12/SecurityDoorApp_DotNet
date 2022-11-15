using AutoMapper;
using Security_Door_App.Data.Models;
using Security_Door_App.Logic.DTOs;

namespace Security_Door_App.Logic.Mappings
{
    public class DoorProfile :Profile
    {
        public DoorProfile()
        {
            CreateMap<CreateDoorDTO, Door>().ReverseMap();
        }
    }
}
