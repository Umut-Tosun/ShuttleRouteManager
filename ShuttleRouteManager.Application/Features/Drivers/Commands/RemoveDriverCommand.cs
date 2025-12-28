using MediatR;
using ShuttleRouteManager.Application.Base;

namespace ShuttleRouteManager.Application.Features.Drivers.Commands;

public record RemoveDriverCommand(Guid Id) : IRequest<BaseResult<object>>;