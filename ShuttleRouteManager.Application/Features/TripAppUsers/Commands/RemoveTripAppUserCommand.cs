using MediatR;
using ShuttleRouteManager.Application.Base;

namespace ShuttleRouteManager.Application.Features.TripAppUsers.Commands;

public record RemoveTripAppUserCommand(Guid Id) : IRequest<BaseResult<object>>;



