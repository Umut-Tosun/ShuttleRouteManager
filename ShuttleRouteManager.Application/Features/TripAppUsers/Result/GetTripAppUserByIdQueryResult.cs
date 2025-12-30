using ShuttleRouteManager.Application.Features.AppUsers.Result;
using ShuttleRouteManager.Application.Features.Routes.Result;
using ShuttleRouteManager.Application.Features.RouteStops.Result;
using ShuttleRouteManager.Domain.Absractions;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.TripAppUsers.Result;

public class GetTripAppUserByIdQueryResult : Entity
{
    public Guid AppUserId { get; set; }
    public GetAppUsersQueryResult? AppUser { get; set; }
    public Guid RouteId { get; set; }
    public GetRoutesQueryResult? Route { get; set; }
    public Guid RouteStopId { get; set; }
    public GetRouteStopsQueryResult? RouteStop { get; set; }
    public bool IsMorningTripActive { get; set; }
    public bool IsEveningTripActive { get; set; }
    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ValidUntil { get; set; }
}