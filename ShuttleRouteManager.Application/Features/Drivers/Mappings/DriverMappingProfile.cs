using AutoMapper;
using ShuttleRouteManager.Application.Features.Drivers.Commands;
using ShuttleRouteManager.Application.Features.Drivers.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.Drivers.Mappings;

public class DriverMappingProfile : Profile
{
    public DriverMappingProfile()
    {
        CreateMap<Driver, GetDriversQueryResult>();
        CreateMap<Driver, GetDriverByIdQueryResult>();

       
        CreateMap<Company, CompanySummaryDto>();
        CreateMap<Domain.Entities.Route, RouteSummaryDto>();

        CreateMap<CreateDriverCommand, Driver>();
        CreateMap<UpdateDriverCommand, Driver>();
    }
}
