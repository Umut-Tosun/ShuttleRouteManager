using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Features.RouteStops.Result;

namespace ShuttleRouteManager.Application.Features.RouteStops.Queries;

public record GetRouteStopsByRouteIdQuery(Guid RouteId) : IRequest<BaseResult<List<GetRouteStopsQueryResult>>>;