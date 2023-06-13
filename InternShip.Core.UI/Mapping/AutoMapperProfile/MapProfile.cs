using AutoMapper;
using InternShip.Core.Core.Models;
using InternShip.Core.Dto.Dtos.InternBookDto;
using InternShip.Core.Dto.Dtos.InternPlaceDto;
using InternShip.Core.Dto.Dtos.MessageDto;

namespace InternShip.Core.UI.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<InternPlaceListDto, InternPlace>().ReverseMap();
            CreateMap<InternBookListDto, InternBook>().ReverseMap();
            CreateMap<MessageListDto, Message>().ReverseMap();
        }
    }
}
