using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Features.TripAppUsers.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.TripAppUsers.Commands;

public class UpdateTripAppUserCommand : IRequest<BaseResult<GetTripAppUserByIdQueryResult>>
{
    public Guid Id { get; set; }
    public Guid AppUserId { get; set; }
    public Guid RouteId { get; set; }
    public Guid RouteStopId { get; set; }
    public bool IsMorningTripActive { get; set; }
    public bool IsEveningTripActive { get; set; }
    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ValidUntil { get; set; }
}




