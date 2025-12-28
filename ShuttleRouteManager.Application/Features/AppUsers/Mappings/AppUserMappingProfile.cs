using AutoMapper;
using ShuttleRouteManager.Application.Features.AppUsers.Commands;
using ShuttleRouteManager.Application.Features.AppUsers.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.AppUsers.Mappings;

public class AppUserMappingProfile : Profile
{
    public AppUserMappingProfile()
    {
        CreateMap<AppUser, GetAppUsersQueryResult>().ReverseMap();
        CreateMap<AppUser, GetUserByIdQueryResult>().ReverseMap();
        CreateMap<AppUser, RegisterUserCommand>()
            .ForMember(dest => dest.Password, opt => opt.Ignore())
            .ReverseMap();
        CreateMap<AppUser, UpdateUserCommand>().ReverseMap();
    }
}
