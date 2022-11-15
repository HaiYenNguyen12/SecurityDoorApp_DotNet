﻿using AutoMapper;
using Security_Door_App.Data.Models;
using Security_Door_App.Logic.DTOs;

namespace Security_Door_App.Logic.Mappings
{
    public class DoorReaderProfile :Profile
    {
        public DoorReaderProfile()
        {
            CreateMap<CreateDoorReaderDTO, DoorReader>().ReverseMap();
        }
    }
}
