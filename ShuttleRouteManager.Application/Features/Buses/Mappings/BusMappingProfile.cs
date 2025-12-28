using AutoMapper;
using ShuttleRouteManager.Application.Features.Buses.Commands;
using ShuttleRouteManager.Application.Features.Buses.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.Buses.Mappings;

public class BusMappingProfile : Profile
{
    public BusMappingProfile()
    {
        CreateMap<Bus, GetBusesQueryResult>().ReverseMap();
        CreateMap<Bus, GetBusByIdQueryResult>().ReverseMap();
        CreateMap<Bus, CreateBusCommand>().ReverseMap();
        CreateMap<Bus, UpdateBusCommand>().ReverseMap();
    }
}
