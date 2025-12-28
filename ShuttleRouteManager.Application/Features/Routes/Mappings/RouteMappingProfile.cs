using AutoMapper;
using Microsoft.AspNetCore.Routing;
using ShuttleRouteManager.Application.Features.Routes.Commands;
using ShuttleRouteManager.Application.Features.Routes.Result;

namespace ShuttleRouteManager.Application.Features.Routes.Mappings;

public class RouteMappingProfile : Profile
{
    public RouteMappingProfile()
    {
        CreateMap<Route, GetRoutesQueryResult>().ReverseMap();
        CreateMap<Route, GetRouteByIdQueryResult>().ReverseMap();
        CreateMap<Route, CreateRouteCommand>().ReverseMap();
        CreateMap<Route, UpdateRouteCommand>().ReverseMap();
    }
}
