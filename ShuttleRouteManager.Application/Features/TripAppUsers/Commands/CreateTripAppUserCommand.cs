using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.TripAppUsers.Commands;
public class CreateTripAppUserCommand : IRequest<BaseResult<object>>
{
    public Guid AppUserId { get; set; }
    public Guid RouteId { get; set; }
    public Guid RouteStopId { get; set; }
    public TripType TripType { get; set; }
    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ValidUntil { get; set; }
}



