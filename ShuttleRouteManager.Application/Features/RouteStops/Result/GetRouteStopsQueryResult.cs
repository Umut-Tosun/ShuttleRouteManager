using ShuttleRouteManager.Application.Features.AppUsers.Result;
using ShuttleRouteManager.Application.Features.Routes.Result;
using ShuttleRouteManager.Application.Features.TripAppUsers.Result;
using ShuttleRouteManager.Domain.Absractions;

namespace ShuttleRouteManager.Application.Features.RouteStops.Result;

public class GetRouteStopsQueryResult : Entity
{
    public int SequenceNumber { get; set; }
    public string City { get; set; } = default!;
    public string District { get; set; } = default!;
    public string Address { get; set; } = default!;
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public TimeSpan EstimatedArrivalTimeMorning { get; set; }
    public TimeSpan EstimatedArrivalTimeEvening { get; set; }
    public Guid RouteId { get; set; }
    public GetRoutesQueryResult? Route { get; set; }
    public ICollection<GetAppUsersQueryResult>? DefaultAppUsers { get; set; }
    public ICollection<GetTripAppUsersQueryResult>? TripAppUsers { get; set; }
}
