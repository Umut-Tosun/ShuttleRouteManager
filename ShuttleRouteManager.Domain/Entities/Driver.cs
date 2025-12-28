using ShuttleRouteManager.Domain.Absractions;

namespace ShuttleRouteManager.Domain.Entities;

public sealed class Driver : Entity
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string LicenseNumber { get; set; } = default!;
    public DateTimeOffset JobStartDate { get; set; }    
}
