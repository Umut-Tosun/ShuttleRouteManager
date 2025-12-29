namespace ShuttleRouteManager.Application.Features.Companies.Result;

public class DriverSummaryDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!; 
    public string LicenseNumber { get; set; } = default!;
    public string FullName => $"{FirstName} {LastName}";
}