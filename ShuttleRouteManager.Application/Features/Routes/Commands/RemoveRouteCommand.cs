using MediatR;
using ShuttleRouteManager.Application.Base;

namespace ShuttleRouteManager.Application.Features.Routes.Commands;

public record RemoveRouteCommand(Guid Id) : IRequest<BaseResult<object>>;