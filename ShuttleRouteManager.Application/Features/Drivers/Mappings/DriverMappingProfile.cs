using AutoMapper;
using ShuttleRouteManager.Application.Features.Drivers.Commands;
using ShuttleRouteManager.Application.Features.Drivers.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.Drivers.Mappings;

public class DriverMappingProfile : Profile
{
    public DriverMappingProfile()
    {
        CreateMap<Driver, GetDriversQueryResult>().ReverseMap();
        CreateMap<Driver, GetDriverByIdQueryResult>().ReverseMap();
        CreateMap<Driver, CreateDriverCommand>().ReverseMap();
        CreateMap<Driver, UpdateDriverCommand>().ReverseMap();
    }
}
