using ShuttleRouteManager.Domain.Absractions;

namespace ShuttleRouteManager.Domain.Entities;

public class TripAppUser : Entity
{
    public Guid AppUserId { get; set; }
    public virtual AppUser AppUser { get; set; } = default!;

    public Guid RouteId { get; set; }
    public virtual Route Route { get; set; } = default!;

    public Guid RouteStopId { get; set; }
    public virtual RouteStop RouteStop { get; set; } = default!;

  
    public bool IsMorningTripActive { get; set; }
    public bool IsEveningTripActive { get; set; }

    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ValidUntil { get; set; }
}

// ENUM'U SİL veya yorum satırı yap
/*
public enum TripType
{
    Morning = 1,
    Evening = 2
}
*/
