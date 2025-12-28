using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Features.Routes.Result;

namespace ShuttleRouteManager.Application.Features.Routes.Queries;

public record GetRoutesByBusIdQuery(Guid BusId) : IRequest<BaseResult<List<GetRoutesQueryResult>>>;