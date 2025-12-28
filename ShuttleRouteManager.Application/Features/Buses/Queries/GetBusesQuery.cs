using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Features.Buses.Result;

namespace ShuttleRouteManager.Application.Features.Buses.Queries;

public record GetBusesQuery : IRequest<BaseResult<List<GetBusesQueryResult>>>;
