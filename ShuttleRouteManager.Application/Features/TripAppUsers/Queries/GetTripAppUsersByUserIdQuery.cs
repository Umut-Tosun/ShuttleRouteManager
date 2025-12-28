using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Features.TripAppUsers.Result;

namespace ShuttleRouteManager.Application.Features.TripAppUsers.Queries;

public record GetTripAppUsersByUserIdQuery(Guid UserId) : IRequest<BaseResult<List<GetTripAppUsersQueryResult>>>;