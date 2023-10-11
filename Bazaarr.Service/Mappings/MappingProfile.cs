using AutoMapper;
using Bazaarr.Domain.Models;
using Bazaarr.Service.DTOs.User;

namespace Bazaarr.Service.Mappings;

internal class MappingProfile : Profile
{
    public static IMapper Initialize()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, UserForCreationDto>().ReverseMap();
            cfg.CreateMap<User, UserForUpdateDto>().ReverseMap();
            cfg.CreateMap<User, UserForResultDto>().ReverseMap();
        });

        return config.CreateMapper();
    }
}
