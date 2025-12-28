namespace ShuttleRouteManager.Application.Features.Routes.Result;

public class DriverForRouteSummaryDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}