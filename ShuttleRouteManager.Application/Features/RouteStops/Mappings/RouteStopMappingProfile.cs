using AutoMapper;
using ShuttleRouteManager.Application.Features.RouteStops.Commands;
using ShuttleRouteManager.Application.Features.RouteStops.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.RouteStops.Mappings;

public class RouteStopMappingProfile : Profile
{
    public RouteStopMappingProfile()
    {
        CreateMap<RouteStop, GetRouteStopsQueryResult>().ReverseMap();
        CreateMap<RouteStop, GetRouteStopByIdQueryResult>().ReverseMap();
        CreateMap<RouteStop, CreateRouteStopCommand>().ReverseMap();
        CreateMap<RouteStop, UpdateRouteStopCommand>().ReverseMap();
    }
}
