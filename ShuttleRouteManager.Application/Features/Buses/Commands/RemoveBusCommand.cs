using MediatR;
using ShuttleRouteManager.Application.Base;

namespace ShuttleRouteManager.Application.Features.Buses.Commands;

public record RemoveBusCommand(Guid Id) : IRequest<BaseResult<object>>;