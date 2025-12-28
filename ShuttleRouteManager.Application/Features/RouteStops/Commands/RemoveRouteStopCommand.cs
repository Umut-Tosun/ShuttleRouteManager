using MediatR;
using ShuttleRouteManager.Application.Base;

namespace ShuttleRouteManager.Application.Features.RouteStops.Commands;

public record RemoveRouteStopCommand(Guid Id) : IRequest<BaseResult<object>>;