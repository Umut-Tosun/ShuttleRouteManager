using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.RouteStops.Queries;
using ShuttleRouteManager.Application.Features.RouteStops.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.RouteStops.Handlers;

public class GetRouteStopsQueryHandler(
    IRepository<RouteStop> repository,
    IMapper mapper) : IRequestHandler<GetRouteStopsQuery, BaseResult<List<GetRouteStopsQueryResult>>>
{
    public async Task<BaseResult<List<GetRouteStopsQueryResult>>> Handle(GetRouteStopsQuery request, CancellationToken cancellationToken)
    {
        var routeStops = await repository.GetAllAsync();
        var result = mapper.Map<List<GetRouteStopsQueryResult>>(routeStops);
        return BaseResult<List<GetRouteStopsQueryResult>>.Success(result);
    }
}