using Microsoft.AspNetCore.Identity;

namespace ShuttleRouteManager.Domain.Entities;

public sealed class AppUser : IdentityUser<Guid>
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
    public string HomeLatitude { get; set; } = default!;
    public string HomeLongitude { get; set; } = default!;

    public DateTimeOffset CreatedDate { get; set; } = DateTime.Now;
    public Guid CreateUserId { get; set; } = default!;
    public DateTimeOffset LastUpdatedDate { get; set; }
    public Guid? LastUpdateUserId { get; set; }
    public bool IsDeleted { get; set; } = false;
    public Guid? DeletedUserId { get; set; }
    public DateTimeOffset? DeletedDate { get; set; }



}
