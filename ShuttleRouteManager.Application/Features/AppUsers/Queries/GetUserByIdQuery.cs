using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Features.AppUsers.Result;

namespace ShuttleRouteManager.Application.Features.AppUsers.Queries;

public record GetUserByIdQuery(Guid Id) : IRequest<BaseResult<GetUserByIdQueryResult>>;