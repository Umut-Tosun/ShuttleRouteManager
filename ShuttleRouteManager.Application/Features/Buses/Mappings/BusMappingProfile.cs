using AutoMapper;
using ShuttleRouteManager.Application.Features.Buses.Commands;
using ShuttleRouteManager.Application.Features.Buses.Result;
using ShuttleRouteManager.Application.Features.Drivers.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.Buses.Mappings;

public class BusMappingProfile : Profile
{
    public BusMappingProfile()
    {
        CreateMap<Bus, GetBusesQueryResult>();
        CreateMap<Bus, GetBusByIdQueryResult>();

       
        CreateMap<Company, CompanySummaryDto>();
        CreateMap<Domain.Entities.Route, RouteSummaryDto>();

        CreateMap<CreateBusCommand, Bus>();
        CreateMap<UpdateBusCommand, Bus>();
    }
}
