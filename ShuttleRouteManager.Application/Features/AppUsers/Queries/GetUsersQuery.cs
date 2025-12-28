using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Features.AppUsers.Result;

namespace ShuttleRouteManager.Application.Features.AppUsers.Queries;

public record GetUsersQuery : IRequest<BaseResult<List<GetAppUsersQueryResult>>>;
