using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Features.Routes.Result;

namespace ShuttleRouteManager.Application.Features.Routes.Queries;

public record GetRoutesQuery : IRequest<BaseResult<List<GetRoutesQueryResult>>>;
