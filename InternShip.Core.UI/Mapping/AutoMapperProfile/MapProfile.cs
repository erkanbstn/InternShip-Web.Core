using AutoMapper;
using InternShip.Core.Core.Models;
using InternShip.Core.Dto.Dtos.InternPlaceDto;

namespace InternShip.Core.UI.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<InternPlaceListDto, InternPlace>().ReverseMap();
        }
    }
}
