using AutoMapper;
using Security_Door_App.Data.Models;
using Security_Door_App.Logic.DTOs;
using Security_Door_App.Logic.ViewModels;

namespace Security_Door_App.Logic.Mappings
{
    public class CardProfile :Profile
    {
        public CardProfile()
        {
            CreateMap<CreateCardDTO, Card>().ReverseMap();
            CreateMap<Card, CardVM>()
            .ForMember(dest => dest.CardLevel, act => act.MapFrom(scr => scr.Status))
            .ForMember(dest => dest.CardStatus, act => act.MapFrom(scr => scr.Level))
            .ReverseMap();



        }
    }
}
