using ShuttleRouteManager.Domain.Absractions;

namespace ShuttleRouteManager.Domain.Entities;

public  class TripAppUser : Entity
{
   
    public Guid AppUserId { get; set; }
    public virtual AppUser AppUser { get; set; } = default!;
    public Guid RouteId { get; set; }
    public virtual Route Route { get; set; } = default!;
    public Guid RouteStopId { get; set; }
    public virtual RouteStop RouteStop { get; set; } = default!;
    public TripType TripType { get; set; }
    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ValidUntil { get; set; }
}
public enum TripType
{
    Morning = 1,
    Evening = 2
}
