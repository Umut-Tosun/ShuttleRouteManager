using ShuttleRouteManager.Domain.Absractions;

namespace ShuttleRouteManager.Domain.Entities;

public class Driver : Entity
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string LicenseNumber { get; set; } = default!;
    public DateTimeOffset JobStartDate { get; set; }
    public Guid CompanyId { get; set; }
    public virtual Company Company { get; set; } = default!;
    public virtual ICollection<Route> Routes { get; set; } = new List<Route>();
}
