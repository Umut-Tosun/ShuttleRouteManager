using AutoMapper;
using Microsoft.AspNetCore.Routing;
using ShuttleRouteManager.Application.Features.Routes.Commands;
using ShuttleRouteManager.Application.Features.Routes.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.Routes.Mappings;

public class RouteMappingProfile : Profile
{
    public RouteMappingProfile()
    {
        CreateMap<Domain.Entities.Route, GetRoutesQueryResult>();
        CreateMap<Domain.Entities.Route, GetRouteByIdQueryResult>();

        CreateMap<Bus, BusForRouteSummaryDto>();
        CreateMap<Driver, DriverForRouteSummaryDto>();
        CreateMap<RouteStop, RouteStopForRouteDto>();

        CreateMap<CreateRouteCommand, Domain.Entities.Route>();
        CreateMap<UpdateRouteCommand, Domain.Entities.Route>();
    }
}
