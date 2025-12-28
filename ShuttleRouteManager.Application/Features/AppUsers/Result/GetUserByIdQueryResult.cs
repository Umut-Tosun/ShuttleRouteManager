using ShuttleRouteManager.Application.Features.RouteStops.Result;
using ShuttleRouteManager.Application.Features.TripAppUsers.Result;
using ShuttleRouteManager.Domain.Absractions;

namespace ShuttleRouteManager.Application.Features.AppUsers.Result;

public class GetUserByIdQueryResult : Entity
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string HomeCity { get; set; } = default!;
    public string HomeDistrict { get; set; } = default!;
    public string HomeAddress { get; set; } = default!;
    public decimal HomeLatitude { get; set; }
    public decimal HomeLongitude { get; set; }
    public Guid? DefaultRouteStopId { get; set; }
    public GetRouteStopsQueryResult? DefaultRouteStop { get; set; }
    public ICollection<GetTripAppUsersQueryResult>? TripAppUsers { get; set; }
}