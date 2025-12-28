using ShuttleRouteManager.Domain.Absractions;

namespace ShuttleRouteManager.Domain.Entities;

public  class Route : Entity
{
    public string Name { get; set; } = default!;
    public string StartPoint { get; set; } = default!;
    public string EndPoint { get; set; } = default!;
    public TimeSpan MorningStartTime { get; set; }
    public TimeSpan EveningStartTime { get; set; }
    public Guid BusId { get; set; }
    public virtual Bus Bus { get; set; } = default!;
    public Guid DriverId { get; set; }
    public virtual Driver Driver { get; set; } = default!;
    public virtual ICollection<RouteStop> RouteStops { get; set; } = new List<RouteStop>();
    public virtual ICollection<TripAppUser> TripAppUsers { get; set; } = new List<TripAppUser>();

}
