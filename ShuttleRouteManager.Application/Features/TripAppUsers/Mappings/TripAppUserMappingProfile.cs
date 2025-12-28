using AutoMapper;
using ShuttleRouteManager.Application.Features.TripAppUsers.Commands;
using ShuttleRouteManager.Application.Features.TripAppUsers.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.TripAppUsers.Mappings;

public class TripAppUserMappingProfile : Profile
{
    public TripAppUserMappingProfile()
    {
        CreateMap<TripAppUser, GetTripAppUsersQueryResult>().ReverseMap();
        CreateMap<TripAppUser, GetTripAppUserByIdQueryResult>().ReverseMap();
        CreateMap<TripAppUser, CreateTripAppUserCommand>().ReverseMap();
        CreateMap<TripAppUser, UpdateTripAppUserCommand>().ReverseMap();
    }
}
