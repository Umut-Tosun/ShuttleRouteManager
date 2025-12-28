using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.RouteStops.Queries;
using ShuttleRouteManager.Application.Features.RouteStops.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.RouteStops.Handlers;

public class GetRouteStopsByRouteIdQueryHandler(
    IRepository<RouteStop> repository,
    IMapper mapper) : IRequestHandler<GetRouteStopsByRouteIdQuery, BaseResult<List<GetRouteStopsQueryResult>>>
{
    public async Task<BaseResult<List<GetRouteStopsQueryResult>>> Handle(GetRouteStopsByRouteIdQuery request, CancellationToken cancellationToken)
    {
        var routeStops = await repository.GetAllAsync(rs => rs.RouteId == request.RouteId);
        // Sıra numarasına göre sırala
        var orderedStops = routeStops.OrderBy(rs => rs.SequenceNumber).ToList();
        var result = mapper.Map<List<GetRouteStopsQueryResult>>(orderedStops);
        return BaseResult<List<GetRouteStopsQueryResult>>.Success(result);
    }
}