using Microsoft.AspNetCore.Identity;

namespace ShuttleRouteManager.Domain.Entities;

public class AppUser : IdentityUser<Guid>
{
    public AppUser()
    {
        Id = Guid.NewGuid();
    }

    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string HomeCity { get; set; } = default!;
    public string HomeDistrict { get; set; } = default!;
    public string HomeAddress { get; set; } = default!;
    public decimal HomeLatitude { get; set; } = default!;
    public decimal HomeLongitude { get; set; } = default!;

    public DateTimeOffset CreatedDate { get; set; } = DateTime.Now;
    public Guid CreateUserId { get; set; } = default!;
    public DateTimeOffset LastUpdatedDate { get; set; }
    public Guid? LastUpdateUserId { get; set; }
    public bool IsDeleted { get; set; } = false;
    public Guid? DeletedUserId { get; set; }
    public DateTimeOffset? DeletedDate { get; set; }
    public Guid? DefaultRouteStopId { get; set; }
    public virtual RouteStop? DefaultRouteStop { get; set; } = default!;
    public virtual ICollection<TripAppUser> TripAppUsers { get; set; } = new List<TripAppUser>();

}
