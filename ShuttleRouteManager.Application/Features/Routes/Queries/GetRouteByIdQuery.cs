using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Features.Routes.Result;

namespace ShuttleRouteManager.Application.Features.Routes.Queries;

public record GetRouteByIdQuery(Guid Id) : IRequest<BaseResult<GetRouteByIdQueryResult>>;
