using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Features.Buses.Result;

namespace ShuttleRouteManager.Application.Features.Buses.Queries;

public record GetBusByIdQuery(Guid Id) : IRequest<BaseResult<GetBusByIdQueryResult>>;