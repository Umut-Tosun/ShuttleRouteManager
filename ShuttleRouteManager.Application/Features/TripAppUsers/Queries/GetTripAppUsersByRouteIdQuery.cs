using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Features.TripAppUsers.Result;

namespace ShuttleRouteManager.Application.Features.TripAppUsers.Queries;

public record GetTripAppUsersByRouteIdQuery(Guid RouteId) : IRequest<BaseResult<List<GetTripAppUsersQueryResult>>>;